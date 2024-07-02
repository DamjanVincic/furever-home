using FureverHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
