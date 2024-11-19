using Microsoft.EntityFrameworkCore;
using Pasarela.Entity;

namespace Pasarela.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Pago> Pagos { get; set; }
    }
}