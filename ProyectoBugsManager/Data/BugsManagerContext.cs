using Microsoft.EntityFrameworkCore;
using ProyectoBugsManager.Models;

namespace ProyectoBugsManager.Data
{
    public class BugsManagerContext : DbContext
    {
        public BugsManagerContext(DbContextOptions<BugsManagerContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<Error> Errores { get; set; }
    }
}
