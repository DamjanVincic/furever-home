using FureverHome.Models;

namespace FureverHome.Repositories.PostgresRepositories
{
    public class PostPostgresRepository : IPostRepository
    {
        private readonly DatabaseContext _dbContext;

        public PostPostgresRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Post post)
        {
            _dbContext.Posts.Add(post);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Post? post = _dbContext.Posts.Find(id);
            if (post == null) return;

            _dbContext.Posts.Remove(post);
            _dbContext.SaveChanges();
        }

        public List<Post> GetAll()
        {
            return _dbContext.Posts.ToList();
        }

        public Post? GetById(int id)
        {
            return _dbContext.Posts.Find(id);
        }

        public void Update(Post post)
        {
            _dbContext.Posts.Update(post);
            _dbContext.SaveChanges();
        }
    }
}
