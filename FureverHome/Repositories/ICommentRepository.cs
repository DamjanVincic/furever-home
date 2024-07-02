using FureverHome.Models;

namespace FureverHome.Repositories
{
    public interface ICommentRepository
    {
        List<Comment> GetAll();
        Comment? GetById(int id);
        void Add(Comment comment);
        void Update(Comment comment);
        void Delete(int id);
    }
}
