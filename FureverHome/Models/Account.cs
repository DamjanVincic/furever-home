namespace FureverHome.Models
{
    public class Account
    {
        public Account()
        {
        }

        public Account(string username, string password, int userId, AccountType type, AccountStatus status)
        {
            UserName = username;
            Password = password;
            Type = type;
            Status = status;
            UserId = userId;
        }

        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int UserId { get; set; }
        public virtual User User { get; set; } = null!;
        public AccountType Type { get; set; }
        public AccountStatus Status { get; set; }
    }
}