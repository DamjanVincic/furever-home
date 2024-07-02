using FureverHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FureverHome.Repositories
{
    public interface IAdoptionRequestRepository
    {
        List<AdoptionRequest> GetAll();
        AdoptionRequest? GetById(int id);
        void Add(AdoptionRequest adoptionRequest);
        void Update(AdoptionRequest adoptionRequest);
        void Delete(int id);
    }
}
