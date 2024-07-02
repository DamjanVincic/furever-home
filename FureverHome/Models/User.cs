namespace FureverHome.Models
{
    public class User
    {
        public User()
        {
        }

        public User(string firstName, string lastName, Gender gender, string phone, string address)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            Phone = phone;
            Address = address;
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public Gender Gender { get; set; }
        public string Phone { get; set; } = null!;
        public string Address { get; set; } = null!;
        public virtual List<AdoptionRequest> AdoptionRequests { get; set; } = [];
    }
}