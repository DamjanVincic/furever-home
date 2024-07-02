namespace FureverHome.Models
{
    public class Color
    {
        public Color()
        {
        }
        
        public Color(string name)
        {
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public override string ToString()
        {
            return Name;
        }
    }
}