using FureverHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FureverHome.Repositories
{
    public interface IAssociationRepository
    {
        List<Association> GetAll();
        Association? GetById(int id);
        void Add(Association association);
        void Update(Association association);
        void Delete(int id);
    }
}
