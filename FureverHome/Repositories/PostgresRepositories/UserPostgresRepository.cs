using FureverHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FureverHome.Repositories.PostgresRepositories
{
    public class UserPostgresRepository : IUserRepository
    {
        private readonly DatabaseContext _dbContext;

        public UserPostgresRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Add(User user)
        {
            var addedUser = _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return addedUser.Entity.Id;
        }

        public void Delete(int id)
        {
            User? user = _dbContext.Users.Find(id);
            if (user == null) return;

            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
        }

        public List<User> GetAll()
        {
            return _dbContext.Users.ToList();
        }

        public User? GetById(int id)
        {
            return _dbContext.Users.Find(id);
        }

        public void Update(User user)
        {
            _dbContext.Users.Update(user);
            _dbContext.SaveChanges();
        }
    }

}
