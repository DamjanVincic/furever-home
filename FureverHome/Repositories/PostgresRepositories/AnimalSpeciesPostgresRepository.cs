using FureverHome.Models;

namespace FureverHome.Repositories.PostgresRepositories
{
    public class AnimalSpeciesPostgresRepository : IAnimalSpeciesRepository
    {
        private readonly DatabaseContext _dbContext;

        public AnimalSpeciesPostgresRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(AnimalSpecies animalSpecies)
        {
            _dbContext.AnimalSpecies.Add(animalSpecies);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            AnimalSpecies? animalSpecies = _dbContext.AnimalSpecies.Find(id);
            if (animalSpecies == null) return;

            _dbContext.AnimalSpecies.Remove(animalSpecies);
            _dbContext.SaveChanges();
        }

        public List<AnimalSpecies> GetAll()
        {
            return _dbContext.AnimalSpecies.ToList();
        }

        public AnimalSpecies? GetById(int id)
        {
            return _dbContext.AnimalSpecies.Find(id);
        }

        public void Update(AnimalSpecies animalSpecies)
        {
            _dbContext.AnimalSpecies.Update(animalSpecies);
            _dbContext.SaveChanges();
        }
    }

}
