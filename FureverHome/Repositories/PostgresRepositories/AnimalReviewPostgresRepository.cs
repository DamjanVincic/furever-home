using FureverHome.Models;

namespace FureverHome.Repositories.PostgresRepositories
{
    public class AnimalReviewPostgresRepository : IAnimalReviewRepository
    {
        private readonly DatabaseContext _dbContext;

        public AnimalReviewPostgresRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(AnimalReview animalReview)
        {
            _dbContext.AnimalReviews.Add(animalReview);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            AnimalReview? animalReview = _dbContext.AnimalReviews.Find(id);
            if (animalReview == null) return;

            _dbContext.AnimalReviews.Remove(animalReview);
            _dbContext.SaveChanges();
        }

        public List<AnimalReview> GetAll()
        {
            return _dbContext.AnimalReviews.ToList();
        }

        public AnimalReview? GetById(int id)
        {
            return _dbContext.AnimalReviews.Find(id);
        }

        public void Update(AnimalReview animalReview)
        {
            _dbContext.AnimalReviews.Update(animalReview);
            _dbContext.SaveChanges();
        }
    }
}
