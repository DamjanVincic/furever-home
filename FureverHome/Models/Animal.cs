namespace FureverHome.Models
{
    public class Animal
    {
        public Animal()
        {
        }

        public Animal(int id, string name, string foundLocation, string healthStatus, DateTime birthYear)
        {
            Id = id;
            Name = name;
            FoundLocation = foundLocation;
            HealthStatus = healthStatus;
            BirthYear = birthYear;
        }

        public Animal(string name, string foundLocation, string healthStatus, DateTime birthYear, int animalBreedId, int colorId)
        {
            Name = name;
            FoundLocation = foundLocation;
            HealthStatus = healthStatus;
            BirthYear = birthYear;
            AnimalBreedId = animalBreedId;
            ColorId = colorId;
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string FoundLocation { get; set; } = null!;
        public string HealthStatus { get; set; } = null!;
        public DateTime BirthYear { get; set; }
        public int AnimalBreedId { get; set; }
        public virtual AnimalBreed AnimalBreed { get; set; } = null!;
        public int ColorId { get; set; }
        public virtual Color Color { get; set; } = null!;
    }
}