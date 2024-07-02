namespace FureverHome.Models
{
    public class AnimalReview
    {
        public AnimalReview()
        {
        }

        public int Id { get; set; }
        public int Rating { get; set; }
        public string Text { get; set; } = null!;
        public int UserId { get; set; }
        public virtual User User { get; set; } = null!;
        public int AnimalId { get; set; }
        public virtual Animal Animal { get; set; } = null!;
    }
}