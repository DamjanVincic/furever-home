namespace FureverHome.Models
{
    public class Association
    {
        public Association()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string BankAccount { get; set; } = null!;
    }
}