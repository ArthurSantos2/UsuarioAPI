using Microsoft.EntityFrameworkCore;
using UsuarioAPI.Entities;

namespace UsuarioAPI.Data
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options) 
        {
            bool databaseExists = Database.CanConnect();

            if (!databaseExists)
            {
                Database.Migrate();
            }
            
        }

        public DbSet<Users> Users { get; set; }

    }
}
