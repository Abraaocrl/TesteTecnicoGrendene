using Microsoft.EntityFrameworkCore;
using TesteTecnicoGrendene.Domain.Usuarios;

namespace TesteTecnicoGrendene.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
