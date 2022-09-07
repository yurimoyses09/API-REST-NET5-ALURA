using alura_api_filmes.Models;
using Microsoft.EntityFrameworkCore;

namespace alura_api_filmes.Data
{
    public class FilmeContext : DbContext
    {
        public FilmeContext(DbContextOptions<FilmeContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Endereco>()
                .HasOne(endereco => endereco.Cinema)
                .WithOne(cinema => cinema.Endereco)
                .HasForeignKey<Cinema>(cinema => cinema.EnderecoId);
        
        }


        public DbSet<Filme> Filme { get; set; }
        public DbSet<Cinema> Cinema { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Gerente> Gerente { get; set; }
    }
}
