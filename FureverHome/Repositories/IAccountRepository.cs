using FureverHome.Models;

namespace FureverHome.Repositories
{
    public interface IAccountRepository
    {
        public List<Account> GetAll();
        public Account? GetById(int id);
        public int Add(Account account);
        public void Update(Account account);
        public void Delete(int id);
    }
}
