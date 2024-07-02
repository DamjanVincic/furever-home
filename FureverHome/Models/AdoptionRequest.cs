namespace FureverHome.Models
{
    public class AdoptionRequest
    {
        public int Id { get; set; }
        public int Duration { get; set; }
        public bool Permanent { get; set; }
        public bool Approved { get; set; }
        public int PostId { get; set; }
        public virtual Post Post { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}