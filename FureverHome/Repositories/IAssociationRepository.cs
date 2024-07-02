using FureverHome.Models;

namespace FureverHome.Repositories
{
    public interface IAssociationRepository
    {
        Association Get();
        void Add(Association association);
        void Update(Association association);
    }
}
