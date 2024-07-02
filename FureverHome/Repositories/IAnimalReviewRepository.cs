using FureverHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
