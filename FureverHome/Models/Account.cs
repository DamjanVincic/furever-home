namespace FureverHome.Models
{
    public class Account
    {
        public Account()
        {
        }
        public Account(string username, string password, AccountType type)
        {
            UserName = username;
            Password = password;
            Type = type;
        }
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public AccountType Type { get; set; }
        public AccountStatus Status { get; set; }
    }
}