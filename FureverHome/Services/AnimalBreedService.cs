using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public List<AnimalBreed> getAll()
        {
            return _animalBreedRepository.GetAll();
        }
    }
}
