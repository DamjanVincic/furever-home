using FureverHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
