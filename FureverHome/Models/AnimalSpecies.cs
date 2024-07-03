namespace FureverHome.Models
{
    public class AnimalSpecies
    {
        public AnimalSpecies()
        {
        }
        
        public AnimalSpecies(string name)
        {
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}