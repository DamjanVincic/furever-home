﻿using FureverHome.Models;

namespace FureverHome.Repositories.PostgresRepositories
{
    public class AssociationPostgresRepository : IAssociationRepository
    {
        private readonly DatabaseContext _dbContext;

        public AssociationPostgresRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Association association)
        {
            _dbContext.Associations.Add(association);
            _dbContext.SaveChanges();
        }

        public Association Get()
        {
            return _dbContext.Associations.First();
        }

        public void Update(Association association)
        {
            _dbContext.Associations.Update(association);
            _dbContext.SaveChanges();
        }
    }
}
