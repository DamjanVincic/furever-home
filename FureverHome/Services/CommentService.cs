using FureverHome.Models;
using FureverHome.Repositories;

namespace FureverHome.Services
{
    public class CommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IPostRepository _postRepository;

        public CommentService(ICommentRepository commentRepository, IPostRepository postRepository)
        {
            _commentRepository = commentRepository;
            _postRepository = postRepository;
        }

        public List<Comment> GetAll()
        {
            return _commentRepository.GetAll();
        }

        public List<Comment> GetByPostId(int postId)
        {
            Post post = _postRepository.GetById(postId)!;
            return post.Comments;
        }
        public void Add(string text,int id,int postId)
        {
            _commentRepository.Add(new Comment(text,id,postId));
        }
    }
}