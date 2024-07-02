using FureverHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FureverHome.Repositories;

namespace FureverHome.Repositories.PostgresRepositories
{
    public class AccountPostgresRepository : IAccountRepository
    {
        private readonly DatabaseContext _dbContext;

        public AccountPostgresRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Account account)
        {
            _dbContext.Accounts.Add(account);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Account? account = _dbContext.Accounts.Find(id);
            if (account == null) return;

            _dbContext.Accounts.Remove(account);
            _dbContext.SaveChanges();
        }

        public List<Account> GetAll()
        {
            return _dbContext.Accounts.ToList();
        }

        public Account? GetById(int id)
        {
            return _dbContext.Accounts.Find(id);
        }

        public void Update(Account account)
        {
            _dbContext.Accounts.Update(account);
            _dbContext.SaveChanges();
        }
    }
}
