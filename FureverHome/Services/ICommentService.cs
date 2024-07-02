using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FureverHome.Models;

namespace FureverHome.Services
{
    public interface ICommentService
    {
       public List<Comment> GetAll();
    }
}
