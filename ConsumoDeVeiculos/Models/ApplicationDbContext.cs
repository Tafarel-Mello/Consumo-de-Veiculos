using Microsoft.EntityFrameworkCore;
using ConsumoDeVeiculos.Models;

namespace ConsumoDeVeiculos.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Consumo> Consumo { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}
