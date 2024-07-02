using FureverHome.Models;

namespace FureverHome.Repositories
{
    public interface IMessageRepository
    {
        List<Message> GetAll();
        Message? GetById(int id);
        void Add(Message message);
        void Update(Message message);
        void Delete(int id);
    }
}
