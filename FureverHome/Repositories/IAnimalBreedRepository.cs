using FureverHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
