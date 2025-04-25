using MenuEduca01.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace MenuEduca01.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CadastroUsuario> Usuarios { get; set; }
        public DbSet<Cardapio> Cardapios { get; set; }
        public DbSet<InsercaoMedica> InsercaoMedicas { get; set; }
        public DbSet<Avaliacao> Avaliacaos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<CadastroUsuario>().ToTable("Usuarios");
            builder.Entity<Cardapio>().ToTable("Cardapios");
            builder.Entity<InsercaoMedica>().ToTable("InsercaoMedicas");
            builder.Entity<Avaliacao>().ToTable("Avaliacaos");
        }
    }
}
