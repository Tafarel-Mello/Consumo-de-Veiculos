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
        public DbSet<ConsumoDeVeiculos.Models.Veiculo> Veiculo { get; set; }

    }
}
