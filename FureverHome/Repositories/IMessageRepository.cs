using FureverHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FureverHome.Repositories
{
    public interface IMessageRepository
    {
        List<Message> GetAll();
        Message? GetById(int id);
        void Add(Message message);
        void Update(Message message);
        void Delete(int id);
    }
}
