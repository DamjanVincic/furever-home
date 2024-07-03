using FureverHome.Models;

namespace FureverHome.Repositories.PostgresRepositories
{
    public class AccountPostgresRepository : IAccountRepository
    {
        private readonly DatabaseContext _dbContext;

        public AccountPostgresRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Add(Account account)
        {
            var acc = _dbContext.Accounts.Add(account);
            _dbContext.SaveChanges();
            return acc.Entity.Id;
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
