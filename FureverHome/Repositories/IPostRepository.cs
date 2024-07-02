using FureverHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FureverHome.Repositories
{
    public interface IPostRepository
    {
        List<Post> GetAll();
        Post? GetById(int id);
        void Add(Post post);
        void Update(Post post);
        void Delete(int id);
    }
}
