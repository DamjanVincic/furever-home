using FureverHome.Models;

namespace FureverHome.Repositories
{
    public interface IAnimalBreedRepository
    {
        List<AnimalBreed> GetAll();
        AnimalBreed? GetById(int id);
        void Add(AnimalBreed animalBreed);
        void Update(AnimalBreed animalBreed);
        void Delete(int id);
    }
}
