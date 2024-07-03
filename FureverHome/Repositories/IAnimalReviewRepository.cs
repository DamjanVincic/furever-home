using FureverHome.Models;

namespace FureverHome.Repositories
{
    public interface IAnimalReviewRepository
    {
        List<AnimalReview> GetAll();
        AnimalReview? GetById(int id);
        void Add(AnimalReview animalReview);
        void Update(AnimalReview animalReview);
        void Delete(int id);
    }
}
