namespace FureverHome.Models
{
    public class User
    {
        public User()
        {
        }

        public User(string firstName, string lastName, Gender gender, string phone, string adress, Account account)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            Phone = phone;
            Adress = adress;
            Account = account;
            AccountId = account.Id;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public virtual List<AdoptionRequest> AdoptionRequests { get; set; } = [];
    }
}