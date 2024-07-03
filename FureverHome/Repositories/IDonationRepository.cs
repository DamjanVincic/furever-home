using FureverHome.Models;

namespace FureverHome.Repositories
{
    public interface IDonationRepository
    {
        List<Donation> GetAll();
        Donation? GetById(int id);
        void Add(Donation donation);
        void Update(Donation donation);
        void Delete(int id);
    }
}
