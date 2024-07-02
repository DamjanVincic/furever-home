using FureverHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FureverHome.Repositories
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User? GetById(int id);
        int Add(User user);
        void Update(User user);
        void Delete(int id);
    }
}
