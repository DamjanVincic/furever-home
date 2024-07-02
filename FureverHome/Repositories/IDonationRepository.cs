using FureverHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
