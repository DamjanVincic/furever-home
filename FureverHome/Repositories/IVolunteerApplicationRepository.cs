using FureverHome.Models;

namespace FureverHome.Repositories
{
    public interface IVolunteerApplicationRepository
    {
        List<VolunteerApplication> GetAll();
        VolunteerApplication? GetById(int id);
        void Add(VolunteerApplication volunteerApplication);
        void Update(VolunteerApplication volunteerApplication);
        void Delete(int id);
    }
}
