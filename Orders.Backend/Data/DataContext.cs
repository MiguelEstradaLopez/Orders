using Microsoft.EntityFrameworkCore;
using Orders.Shared.Entities; // Importa las entidades compartidas

namespace Orders.Backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; } // DbSet para la tabla de países

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configura un índice único en el campo 'Name' para evitar duplicados
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();
        }
    }
}