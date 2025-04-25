using MenuEduca01.Models;
using Microsoft.AspNetCore.Identity;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CadastroUsuario>().ToTable("Usuarios");
            modelBuilder.Entity<Cardapio>().ToTable("Cardapios");
            modelBuilder.Entity<InsercaoMedica>().ToTable("InsercaoMedicas");
            modelBuilder.Entity<Avaliacao>().ToTable("Avaliacaos");

            // Cadastrando as Roles padrão do Sistema 
            Guid CadastroUsuario = Guid.NewGuid();
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = CadastroUsuario.ToString(),
                    Name = "CadastroUsuario",
                    NormalizedName = "CADASTROUSUARIO"
                },
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Aluno",
                    NormalizedName = "ALUNO"
                },
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Nutricionista",
                    NormalizedName = "NUTRICIONISTA"
                }
            );
        }
    }
}
