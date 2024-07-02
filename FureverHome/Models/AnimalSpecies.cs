namespace FureverHome.Models
{
    public class AnimalSpecies
    {
        public AnimalSpecies()
        {
        }
        public AnimalSpecies(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}