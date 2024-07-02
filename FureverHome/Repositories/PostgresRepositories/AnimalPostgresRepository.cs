using FureverHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FureverHome.Repositories.PostgresRepositories
{
    public class AnimalPostgresRepository : IAnimalRepository
    {
        private readonly DatabaseContext _dbContext;

        public AnimalPostgresRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Animal animal)
        {
            _dbContext.Animals.Add(animal);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Animal? animal = _dbContext.Animals.Find(id);
            if (animal == null) return;

            _dbContext.Animals.Remove(animal);
            _dbContext.SaveChanges();
        }

        public List<Animal> GetAll()
        {
            return _dbContext.Animals.ToList();
        }

        public Animal? GetById(int id)
        {
            return _dbContext.Animals.Find(id);
        }

        public void Update(Animal animal)
        {
            _dbContext.Animals.Update(animal);
            _dbContext.SaveChanges();
        }
    }
}
