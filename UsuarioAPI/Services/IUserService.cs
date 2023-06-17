using UsuarioAPI.Entities;

namespace UsuarioAPI.Services
{
    public interface IUserService
    {
        IEnumerable<Users> GetUsers();
        Users GetById(int id);
        void Insert(Users user);
        void Update(int id, Users user);
        void Delete(int id);
    }
}
