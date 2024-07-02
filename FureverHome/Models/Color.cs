namespace FureverHome.Models
{
    public class Color
    {
        public Color()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}