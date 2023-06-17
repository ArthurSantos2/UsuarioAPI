using UsuarioAPI.Entities;
using UsuarioAPI.Repository;

namespace UsuarioAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Delete(int id)
        {
            _userRepository.Delete(id);
        }

        public Users GetById(int id)
        {
            var user = _userRepository.GetById(id);
            return user;
        }

        public IEnumerable<Users> GetUsers()
        {
            var user = _userRepository.GetUsers();
            return user;
        }

        public void Insert(Users user)
        {
           _userRepository.Insert(user);
        }

        public void Update(int id, Users user)
        {
            _userRepository.Update(id, user);
        }
    }
}
