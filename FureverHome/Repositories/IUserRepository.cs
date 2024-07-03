using FureverHome.Models;

namespace FureverHome.Repositories
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User? GetById(int id);
        int Add(User user);
        void Update(User user);
        void Delete(int id);
    }
}
