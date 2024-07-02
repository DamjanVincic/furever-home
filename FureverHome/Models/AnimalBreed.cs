namespace FureverHome.Models
{
    public class AnimalBreed
    {
        public AnimalBreed()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int AnimalSpeciesId { get; set; }
        public virtual AnimalSpecies AnimalSpecies { get; set; }
    }
}