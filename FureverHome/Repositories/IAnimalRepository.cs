using FureverHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FureverHome.Repositories
{
    public interface IAnimalRepository
    {
        List<Animal> GetAll();
        Animal? GetById(int id);
        void Add(Animal animal);
        void Update(Animal animal);
        void Delete(int id);
    }
}
