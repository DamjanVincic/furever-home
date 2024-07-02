using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FureverHome.Models;
using FureverHome.Repositories;

namespace FureverHome.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        public CommentService(ICommentRepository commentRepository) {
            _commentRepository = commentRepository;
        }
        public List<Comment> GetAll()
        {
            return _commentRepository.GetAll();
        }
    }
}
