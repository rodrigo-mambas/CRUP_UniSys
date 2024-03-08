using CRUP.Infra.Mappings;
using CRUP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace CRUP.Infra
{
    [ExcludeFromCodeCoverage]
    public class CRUPDataContext : DbContext
    {
        public CRUPDataContext(DbContextOptions<CRUPDataContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMap());
        }
    }
}
