using UsuarioAPI.Data;
using UsuarioAPI.Entities;

namespace UsuarioAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AplicationDbContext _context;

        public UserRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Users> GetUsers()
        {
            return _context.Users.ToList();
        }

        public Users GetById(int id)
        {
            var user = _context.Users.Find(id);
            
            return user;
        }

        public void Insert(Users user)
        {
  
            _context.Users.Add(user);
            _context.SaveChanges();

        }

        public void Update(int id,Users user)
        {
            var userExists = GetById(id);

            if (userExists != null)
            {
                userExists.Name = user.Name;
                userExists.Email = user.Email;
                userExists.Birthdate = user.Birthdate;

                _context.Users.Update(userExists);
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var user = GetById(id);
            if (user != null)
            {
                _context.Remove(user);
                _context.SaveChanges();
            }

        }
    }
}
