using Microsoft.EntityFrameworkCore;
using ProyectoComunidadesRelativo.Models;

namespace ProyectoComunidadesRelativo.DB
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Password> Passwords { get; set; }

    }
}
