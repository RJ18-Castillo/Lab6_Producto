using Microsoft.EntityFrameworkCore;
using Producto.Models;

namespace Producto.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Producto.Models.Producto> Productos { get; set; }
    }
}