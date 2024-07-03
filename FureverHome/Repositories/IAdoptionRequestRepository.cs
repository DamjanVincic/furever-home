using FureverHome.Models;

namespace FureverHome.Repositories
{
    public interface IAdoptionRequestRepository
    {
        List<AdoptionRequest> GetAll();
        AdoptionRequest? GetById(int id);
        int Add(AdoptionRequest adoptionRequest);
        void Update(AdoptionRequest adoptionRequest);
        void Delete(int id);
    }
}
