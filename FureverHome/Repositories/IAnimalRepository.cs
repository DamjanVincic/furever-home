using FureverHome.Models;

namespace FureverHome.Repositories
{
    public interface IAnimalRepository
    {
        List<Animal> GetAll();
        Animal? GetById(int id); 
        int Add(Animal animal);
        void Update(Animal animal);
        void Delete(int id);
    }
}
