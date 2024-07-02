using FureverHome.Models;

namespace FureverHome.Repositories.PostgresRepositories
{
    public class AnimalBreedPostgresRepository : IAnimalBreedRepository
    {
        private readonly DatabaseContext _dbContext;

        public AnimalBreedPostgresRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(AnimalBreed animalBreed)
        {
            _dbContext.AnimalBreeds.Add(animalBreed);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            AnimalBreed? animalBreed = _dbContext.AnimalBreeds.Find(id);
            if (animalBreed == null) return;

            _dbContext.AnimalBreeds.Remove(animalBreed);
            _dbContext.SaveChanges();
        }

        public List<AnimalBreed> GetAll()
        {
            return _dbContext.AnimalBreeds.ToList();
        }

        public AnimalBreed? GetById(int id)
        {
            return _dbContext.AnimalBreeds.Find(id);
        }

        public void Update(AnimalBreed animalBreed)
        {
            _dbContext.AnimalBreeds.Update(animalBreed);
            _dbContext.SaveChanges();
        }
    }


}
