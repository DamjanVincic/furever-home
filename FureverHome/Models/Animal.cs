namespace FureverHome.Models
{
    public class Animal
    {
        public Animal()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string FoundLocation { get; set; }
        public string HealthStatus { get; set; }
        public DateTime BirthYear { get; set; }
        public int AnimalBreedId { get; set; }
        public virtual AnimalBreed AnimalBreed { get; set; }
        public int ColorId { get; set; }
        public virtual Color Color { get; set; }
    }
}