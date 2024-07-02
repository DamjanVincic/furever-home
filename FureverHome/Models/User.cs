namespace FureverHome.Models
{
    public class User
    {
        public User()
        {
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }
        public virtual List<AdoptionRequest> AdoptionRequests { get; set; } = [];
    }
}