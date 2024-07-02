using FureverHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FureverHome.Repositories
{
    public interface ICommentRepository
    {
        List<Comment> GetAll();
        Comment? GetById(int id);
        void Add(Comment comment);
        void Update(Comment comment);
        void Delete(int id);
    }
}
