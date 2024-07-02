using System.Runtime.InteropServices;

namespace FureverHome.Models
{
    public class Comment
    {
        public Comment()
        {
        }

        public Comment(string text, int userId)
        {
            Text = text;
            UserId = userId;
        }

        public int Id { get; set; }
        public string Text { get; set; } = null!;

        public int UserId { get; set; }
        public virtual User User { get; set; } = null!;

        public int PostId { get; set; }
        public virtual Post Post { get; set; } = null!;
    }
}