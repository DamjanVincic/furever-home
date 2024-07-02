using FureverHome.Models;

namespace FureverHome.Repositories
{
    public interface IAnimalSpeciesRepository
    {
        List<AnimalSpecies> GetAll();
        AnimalSpecies? GetById(int id);
        void Add(AnimalSpecies animalSpecies);
        void Update(AnimalSpecies animalSpecies);
        void Delete(int id);
    }
}
