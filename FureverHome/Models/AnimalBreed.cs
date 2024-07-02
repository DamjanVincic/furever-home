namespace FureverHome.Models
{
    public class AnimalBreed
    {
        public AnimalBreed()
        {
        }

        public AnimalBreed(string name, int animalSpeciesId)
        {
            Name = name;
            AnimalSpeciesId = animalSpeciesId;
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int AnimalSpeciesId { get; set; }
        public virtual AnimalSpecies AnimalSpecies { get; set; } = null!;

        public override string ToString()
        {
            return AnimalSpecies.Name + " " + Name;
        }
    }
}