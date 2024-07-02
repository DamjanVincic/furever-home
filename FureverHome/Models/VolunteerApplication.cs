namespace FureverHome.Models
{
    public class VolunteerApplication
    {
        public VolunteerApplication()
        {
        }
        
        public int Id { get; set; }
        public virtual List<Volunteer> YesVotes { get; set; } = [];
        public virtual List<Volunteer> NoVotes { get; set; } = [];
        public int AuthorId { get; set; }
        public virtual Volunteer Author { get; set; }
        public int UserId { get; set; }
        public virtual RegisteredUser User { get; set; }
    }
}