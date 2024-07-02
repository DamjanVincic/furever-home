using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FureverHome.Models
{
    public class Animal
    {
        public Animal() { }

        public int Id { get; set; }
        public string Name { get; set; }
        public string FoundLocation { get; set; }
        public string HealthStatus { get; set; }
        public DateTime BirthYear { get; set; }
        public int AnimalSpeciesId {  get; set; }
        public AnimalBreed AnimalBreed { get; set; }
        public int ColorId {  get; set; }
        public Color Color {  get; set; }

    }
}
