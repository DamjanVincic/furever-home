using FureverHome.Models;

namespace FureverHome.Repositories
{
    public interface IColorRepository
    {
        List<Color> GetAll();
        Color? GetById(int id);
        void Add(Color color);
        void Update(Color color);
        void Delete(int id);
    }
}
