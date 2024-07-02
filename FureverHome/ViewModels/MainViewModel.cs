using FureverHome.Models;
using FureverHome.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Windows.Input;

namespace FureverHome.ViewModels
{
    public class MainViewModel
    {
        private readonly ObservableCollection<PostViewModel> _posts;
        public MainViewModel()
        {
            List<Post> posts =
            [
                new Post
                {
                    Id = 1,
                    Title = "Post 1",
                    ImageLink = "https://example.com/image1.jpg",
                    Date = DateTime.Now,
                    Status = PostStatus.Active,
                    IsApproved = true,
                    AdoptionRequests = [],
                    Comments = [],
                    AuthorId = 1,
                    Animal = new Animal(1, "kuca", "lokacija1", "zdrav ko dren", DateTime.Now, 1, new AnimalBreed(1, "zlatni retriver", 1, new AnimalSpecies(1, "pas")),1, new Color(1,"crvena"))
                },
                new Post
                {
                    Id = 2,
                    Title = "Post 2",
                    ImageLink = "https://example.com/image2.jpg",
                    Date = DateTime.Now,
                    Status = PostStatus.Active,
                    IsApproved = true,
                    AdoptionRequests = [],
                    Comments = [],
                    AuthorId = 1,
                    Animal = new Animal(2, "macka", "lokacija2", "zdrava", DateTime.Now, 2, new AnimalBreed(2, "persijska macka", 2, new AnimalSpecies(2, "macka")),1, new Color(1,"crvena"))
                },
                // Add more Post objects as needed...
            ];

            List<PostViewModel> postViewModels = posts.Select(post => new PostViewModel(post)).ToList();
            _posts = new ObservableCollection<PostViewModel>(postViewModels);
            LoginCommand = new RelayCommand(Login);
            ViewregistrationRequestsCommand = new RelayCommand(ViewregistrationRequests);

        }

        public IEnumerable<PostViewModel> Posts => _posts;
        public ICommand LoginCommand { get; }
        private void Login()
        {
            var newWindow = new LoginView();
            newWindow.ShowDialog();

        }
        public ICommand ViewregistrationRequestsCommand { get; }
        private void ViewregistrationRequests()
        {
            var newWindow = new RegistrationRequestListingView();
            newWindow.ShowDialog();

        }
    }
}
