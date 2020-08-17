using Microsoft.EntityFrameworkCore;

namespace GBCashback.Models.Base
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
           : base(options)
        {
        }

        public DbSet<Revendedor> Revendedores { get; set; }
        public DbSet<Regra> Regras { get; set; }
        public DbSet<Compra> Compras { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Revendedor
            modelBuilder.Entity<Revendedor>().HasIndex(e => e.CPF).IsUnique();
            modelBuilder.Entity<Revendedor>().HasIndex(e => e.Email).IsUnique();
        }
    }
}