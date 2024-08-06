using Microsoft.EntityFrameworkCore;
using PostoDeGasolina.Models;

namespace PostoDeGasolina.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Combustivel> Combustiveis { get; set; }
    }
}
