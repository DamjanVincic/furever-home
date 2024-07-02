namespace FureverHome.Models
{
    public class AdoptionRequest
    {
        public AdoptionRequest()
        {}
        
        public AdoptionRequest(int duration, bool permanent, int postId, int userId)
        {
            Duration = duration;
            Permanent = permanent;
            PostId = postId;
            UserId = userId;
        }
        
        public int Id { get; set; }
        public int Duration { get; set; }
        public bool Permanent { get; set; }
        public bool Approved { get; set; } = false;
        public int PostId { get; set; }
        public virtual Post Post { get; set; } = null!;
        public int UserId { get; set; }
        public virtual User User { get; set; } = null!;
    }
}