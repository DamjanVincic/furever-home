using FureverHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FureverHome.Repositories.PostgresRepositories
{
    public class CommentPostgresRepository : ICommentRepository
    {
        private readonly DatabaseContext _dbContext;

        public CommentPostgresRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Comment comment)
        {
            _dbContext.Comments.Add(comment);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Comment? comment = _dbContext.Comments.Find(id);
            if (comment == null) return;

            _dbContext.Comments.Remove(comment);
            _dbContext.SaveChanges();
        }

        public List<Comment> GetAll()
        {
            return _dbContext.Comments.ToList();
        }

        public Comment? GetById(int id)
        {
            return _dbContext.Comments.Find(id);
        }

        public void Update(Comment comment)
        {
            _dbContext.Comments.Update(comment);
            _dbContext.SaveChanges();
        }
    }

}
