using Microsoft.OpenApi.Models;
using System.Diagnostics.CodeAnalysis;

namespace CRUP.API.Configuration
{
    [ExcludeFromCodeCoverage]
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "CRUP - Customer Register Unisystem Project",
                    Description = "Esta API faz parte do teste para a vaga de desenvolvedor ASP.NET CORE. Utilizado a licença do MIT.",
                    Contact = new OpenApiContact() { Name = "Rodrigo Clausi Costa", Email = "rodrigo.mambas@gmail.com" },
                    License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
                });

            });
        }
        public static void UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });
        }
    }
}
