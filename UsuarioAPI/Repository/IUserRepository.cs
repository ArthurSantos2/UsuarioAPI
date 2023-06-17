using UsuarioAPI.Entities;

namespace UsuarioAPI.Repository
{
    public interface IUserRepository
    {
        IEnumerable<Users> GetUsers();
        Users GetById(int id);
        void Insert(Users user);
        void Update(int  id, Users user);
        void Delete(int id);
    }
}
