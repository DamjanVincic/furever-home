using FureverHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FureverHome.Repositories.PostgresRepositories
{
    public class ColorPostgresRepository : IColorRepository
    {
        private readonly DatabaseContext _dbContext;

        public ColorPostgresRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Color color)
        {
            _dbContext.Colors.Add(color);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Color? color = _dbContext.Colors.Find(id);
            if (color == null) return;

            _dbContext.Colors.Remove(color);
            _dbContext.SaveChanges();
        }

        public List<Color> GetAll()
        {
            return _dbContext.Colors.ToList();
        }

        public Color? GetById(int id)
        {
            return _dbContext.Colors.Find(id);
        }

        public void Update(Color color)
        {
            _dbContext.Colors.Update(color);
            _dbContext.SaveChanges();
        }
    }
}
