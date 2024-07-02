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
        Association Get();
        void Add(Association association);
        void Update(Association association);
    }
}
