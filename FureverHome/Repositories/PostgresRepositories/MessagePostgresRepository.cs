using FureverHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FureverHome.Repositories.PostgresRepositories
{
    public class MessagePostgresRepository : IMessageRepository
    {
        private readonly DatabaseContext _dbContext;

        public MessagePostgresRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Message message)
        {
            _dbContext.Messages.Add(message);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Message? message = _dbContext.Messages.Find(id);
            if (message == null) return;

            _dbContext.Messages.Remove(message);
            _dbContext.SaveChanges();
        }

        public List<Message> GetAll()
        {
            return _dbContext.Messages.ToList();
        }

        public Message? GetById(int id)
        {
            return _dbContext.Messages.Find(id);
        }

        public void Update(Message message)
        {
            _dbContext.Messages.Update(message);
            _dbContext.SaveChanges();
        }
    }
}
