namespace FureverHome.Models
{
    public class Admin
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }
    }
}