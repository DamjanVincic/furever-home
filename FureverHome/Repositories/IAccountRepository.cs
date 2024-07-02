using FureverHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FureverHome.Repositories
{
    public interface IAccountRepository
    {
        public List<Account> GetAll();
        public Account? GetById(int id);
        public void Add(Account account);
        public void Update(Account account);
        public void Delete(int id);
    }
}
