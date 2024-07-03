using System.Windows.Input;
using FureverHome.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using FureverHome.Views;
using FureverHome.Services;
using System.Windows;

namespace FureverHome.ViewModels
{
    public class PostViewModel : ViewModelBase
    {
        private readonly Post _post;

        public PostViewModel(Post post)
        {
            _post = post;
            CommentCommand = new RelayCommand(ViewComments);
            AdoptCommand = new RelayCommand(Adopt);
        }

        public int Id => _post.Id;
        public string Title => _post.Title;
        public string ImageLink => _post.ImageLink;
        public DateTime Date => _post.Date;
        public PostStatus Status => _post.Status;
        public string Username => _post.Author.FirstName + " " + _post.Author.LastName;
        public Animal Animal => _post.Animal;
        public string AnimalBreed => _post.Animal.AnimalBreed.Name;
        public string AnimalSpecies => _post.Animal.AnimalBreed.AnimalSpecies.Name;
        public string AnimalColor => _post.Animal.Color.Name;
        public string AnimalState => _post.Animal.HealthStatus;
        public string AnimalYear => _post.Animal.BirthYear.ToString();
        public string AnimalLocation => _post.Animal.FoundLocation;
        public string LikesCount => _post.LikedBy.Count.ToString();
        public ICommand CommentCommand { get; }
        public ICommand AdoptCommand { get; }

        private void ViewComments()
        {
            var newWindow = new CommentsListing(Id);
            newWindow.ShowDialog();
        }
        private void Adopt()
        {
            if (UserService.LoggedInAccount == null)
            {
                MessageBox.Show("You have to login in order to adopt", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                var adoptionWindow = new AdoptionPeriodView(Id);
                adoptionWindow.ShowDialog();
            }
        }
    }
}