namespace FureverHome.Models
{
    public class Donation
    {
        public Donation()
        {
        }

        public int Id { get; set; }
        public double Amount { get; set; }
        public bool Anonymous { get; set; }
        public string User { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}