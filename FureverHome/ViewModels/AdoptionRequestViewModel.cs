using FureverHome.Models;

namespace FureverHome.ViewModels
{
    public class AdoptionRequestViewModel
    {
        private readonly AdoptionRequest _adoptionRequest;

        public AdoptionRequestViewModel(AdoptionRequest adoptionRequest)
        {
            _adoptionRequest = adoptionRequest;
        }
        
        public int Id => _adoptionRequest.Id;
        public string Name => $"{_adoptionRequest.User.FirstName} {_adoptionRequest.User.LastName}";
        public string AnimalName => _adoptionRequest.Post.Animal.Name;
        public string Breed => _adoptionRequest.Post.Animal.AnimalBreed.ToString();
        public string Color => _adoptionRequest.Post.Animal.Color.Name;
        public string Birthday => _adoptionRequest.Post.Animal.BirthYear.ToString();
        public string HealthStatus => _adoptionRequest.Post.Animal.HealthStatus;
        public string FoundLocation => _adoptionRequest.Post.Animal.FoundLocation;
        public string Duration => _adoptionRequest.Permanent ? "Permanent" : _adoptionRequest.Duration.ToString();
    }
}
