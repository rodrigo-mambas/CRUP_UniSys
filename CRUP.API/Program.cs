using CRUP.Infra;
using CRUP.Infra.Data.Interfaces;
using CRUP.Infra.Data;
using Microsoft.EntityFrameworkCore;
using CRUP.Domain.Entities;
using CRUP.Application.Interfaces;
using CRUP.Shared.Handlers;
using CRUP.Application.Handlers;
using CRUP.Domain.Commands.Clientes;
using CRUP.Application.Services;
using System.Diagnostics.CodeAnalysis;
using CRUP.API.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("EnableCORS");

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();

[ExcludeFromCodeCoverage]
void ConfigureServices(WebApplicationBuilder builder)
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    builder.Services.AddDbContext<CRUPDataContext>(options =>
    {
        //options.UseSqlServer(connectionString, x => x.MigrationsAssembly("CRUP.Infra"));
        options.UseNpgsql(connectionString, x => x.MigrationsAssembly("CRUP.Infra"));
    });

    builder.Services.AddAuthentication(opt =>
    {
        opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

    // Add services to the container.
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddSwaggerConfiguration();

    builder.Services.AddCors(options =>
    {
        options.AddDefaultPolicy(policy =>
        {
            policy.AllowAnyMethod()
            .AllowAnyOrigin()
            .AllowAnyHeader();
        });
    });

    var services = GetServiceCollection(builder);
}

[ExcludeFromCodeCoverage]
IServiceCollection GetServiceCollection(WebApplicationBuilder builder)
{
    // Adicionando serviços
    var services = builder.Services;
    services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

    services.AddScoped<IReadRepository<Cliente>, ApplicationRepository<Cliente>>();
    services.AddScoped<IWriteRepository<Cliente>, ApplicationRepository<Cliente>>();



    services.AddScoped<IClienteService, ClienteService>();


    services.AddScoped<IHandler<CreateClienteCommand>, CreateClienteHandler>();
    services.AddScoped<IHandler<UpdateClienteCommand>, UpdateClienteHandler>();

    return services;
}

[ExcludeFromCodeCoverage]
public partial class Program { }