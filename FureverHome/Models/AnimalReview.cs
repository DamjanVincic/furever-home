namespace FureverHome.Models
{
    public class AnimalReview
    {
        public AnimalReview()
        {
        }

        public int Id { get; set; }
        public int Rating { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int AnimalId { get; set; }
        public virtual Animal Animal { get; set; }
    }
}