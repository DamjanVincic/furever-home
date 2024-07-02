namespace FureverHome.Models
{
    public class AnimalBreed
    {
        public AnimalBreed()
        {
        }
        public AnimalBreed(int id, string name, int animalSpeciesId, AnimalSpecies animalSpecies)
        {
            Id = id;
            Name = name;
            AnimalSpeciesId = animalSpeciesId;
            AnimalSpecies = animalSpecies;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int AnimalSpeciesId { get; set; }
        public virtual AnimalSpecies AnimalSpecies { get; set; }
    }
}