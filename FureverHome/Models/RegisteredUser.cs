namespace FureverHome.Models
{
    public class RegisteredUser : User
    {
        public RegisteredUser()
        {
        }

        public int TimesReturned { get; set; }
        public virtual List<Message> Messages { get; set; } = [];
    }
}