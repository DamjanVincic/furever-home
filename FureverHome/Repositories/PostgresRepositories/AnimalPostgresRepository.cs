using FureverHome.Models;

namespace FureverHome.Repositories.PostgresRepositories
{
    public class AnimalPostgresRepository : IAnimalRepository
    {
        private readonly DatabaseContext _dbContext;

        public AnimalPostgresRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Add(Animal animal)
        {
            var addedAnimal = _dbContext.Animals.Add(animal);
            _dbContext.SaveChanges();
            return addedAnimal.Entity.Id;
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
