using Microsoft.EntityFrameworkCore;

using UpD8.Teste.Cadastro.Models;

namespace UpD8.Teste.Cadastro.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Cliente { get; set; }
 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().HasKey(u => u.Id);
        }
    }
}
