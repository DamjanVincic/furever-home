using FureverHome.Models;
using FureverHome.Repositories;

namespace FureverHome.Services
{
    public class AnimalBreedService
    {
        private readonly IAnimalBreedRepository _animalBreedRepository;

        public AnimalBreedService(IAnimalBreedRepository animalBreedRepository)
        {
            _animalBreedRepository = animalBreedRepository;
        }

        public List<AnimalBreed> GetAll()
        {
            return _animalBreedRepository.GetAll();
        }
    }
}
