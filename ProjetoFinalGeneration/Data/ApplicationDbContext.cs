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
            ////// configurações adicionais, como chaves estrangeiras
            //modelBuilder.Entity<Usuario>()
            //    .HasMany(p => p.Postagens)
            //    .WithOne(t => t.Usuario)
            //    .HasForeignKey(p => p.UsuarioId);

            //modelBuilder.Entity<Usuario>()
            //    .HasMany(u => u.Postagens)
            //    .WithOne(p => p.Usuario)
            //    .OnDelete(DeleteBehavior.Cascade); // ou .OnDelete(DeleteBehavior.Restrict) dependendo do comportamento desejado


            //modelbuilder.entity<postagem>()
            //    .hasone(p => p.tema)
            //    .withmany(t => t.postagens)
            //    .hasforeignkey(p => p.temaid);

            // Adicione outras configurações conforme necessário
        }
    }
}
