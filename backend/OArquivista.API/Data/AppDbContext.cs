using Microsoft.EntityFrameworkCore;
using OArquivista.API.Models;

namespace OArquivista.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Livro> Livros { get; set; }
    }
}