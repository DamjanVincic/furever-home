using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FureverHome.Models;
using FureverHome.Repositories;

namespace FureverHome.Services
{
    public class CommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IPostRepository _postRepository;
        public CommentService(ICommentRepository commentRepository,IPostRepository postRepository) {
            _commentRepository = commentRepository;
            _postRepository = postRepository;
        }
        public List<Comment> GetAll()
        {
            return _commentRepository.GetAll();
        }
        public List<Comment> GetByPostId(int postId)
        {
            Post post = _postRepository.GetById(postId);
            return post?.Comments ?? new List<Comment>();
        }

    }
}
