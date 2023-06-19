using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using System.Data.Common;
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

                bool migratedDatabaseExists = Database.CanConnect();

                if (!migratedDatabaseExists)
                {
                    throw new DatabaseNotAccesibleException("O banco de dados não está acessível ou não existe.");
                }
            }
        }

        public DbSet<Users> Users { get; set; }

        public class DatabaseNotAccesibleException : Exception
        {
            public DatabaseNotAccesibleException(string message) : base(message)
            {
            }
        }
    }
}
