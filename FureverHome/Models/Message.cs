namespace FureverHome.Models
{
    public class Message
    {
        public Message()
        {
        }

        public int Id { get; set; }
        public string Text { get; set; } = null!;
        public bool FromAssociation { get; set; }
        public DateTime DateTime { get; set; }
    }
}