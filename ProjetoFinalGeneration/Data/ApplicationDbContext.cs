using Microsoft.EntityFrameworkCore;
using ProjetoFinalGeneration.Models;

namespace ProjetoFinalGeneration.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tema> Temas { get; set; }
        public DbSet<Postagem> Postagens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
           .HasIndex(u => u.Email)
           .IsUnique();
        }
    }
}
