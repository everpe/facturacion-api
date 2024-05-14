using Facturacion.Api.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

namespace Facturacion.Api.Persistence
{
    public class FacturacionDataContext : DbContext
    {
        public FacturacionDataContext(DbContextOptions<FacturacionDataContext> options) : base(options)
        {

        }
        public DbSet<Invoice> Invoices { get; set; }
    }
}
