using FureverHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FureverHome.Repositories.PostgresRepositories
{
    public class AdoptionRequestPostgresRepository : IAdoptionRequestRepository
    {
        private readonly DatabaseContext _dbContext;

        public AdoptionRequestPostgresRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(AdoptionRequest adoptionRequest)
        {
            _dbContext.AdoptionRequests.Add(adoptionRequest);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            AdoptionRequest? adoptionRequest = _dbContext.AdoptionRequests.Find(id);
            if (adoptionRequest == null) return;

            _dbContext.AdoptionRequests.Remove(adoptionRequest);
            _dbContext.SaveChanges();
        }

        public List<AdoptionRequest> GetAll()
        {
            return _dbContext.AdoptionRequests.ToList();
        }

        public AdoptionRequest? GetById(int id)
        {
            return _dbContext.AdoptionRequests.Find(id);
        }

        public void Update(AdoptionRequest adoptionRequest)
        {
            _dbContext.AdoptionRequests.Update(adoptionRequest);
            _dbContext.SaveChanges();
        }
    }
}
