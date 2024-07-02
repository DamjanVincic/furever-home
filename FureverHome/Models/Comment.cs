using System.Runtime.InteropServices;

namespace FureverHome.Models
{
    public class Comment
    {
        public Comment()
        {
        }
        public Comment(int id,string text,int userId,User user)
        {
            Id = id;
            Text = text;
            UserId = userId;
            User = user;
        }
        public int Id { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        
        public int PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}