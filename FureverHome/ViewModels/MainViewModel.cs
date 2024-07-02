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
using System.Windows.Media.Imaging;

namespace FureverHome.ViewModels
{
    public class MainViewModel
    {
        private readonly ObservableCollection<PostViewModel> _posts;
        public MainViewModel(Window loginWindow)
        {
            List<Post> posts = new List<Post>
            {
                new Post
                {
                    Id = 1,
                    Title = "Post 1",
                    ImageLink = "https://hipsarden-royalty-free-image-1586966191.jpg?crop=0.752xw:1.00xh;0.175xw,0&resize=1200:*",
                    Date = DateTime.Now,
                    Status = PostStatus.Active,
                    IsApproved = true,
                    AdoptionRequests = new List<AdoptionRequest>(),
                    Comments = new List<Comment>(),
                    LikedBy = new List<User>(),
                    AuthorId = 1,
                    Author = new User("pera","peric",Gender.Male,"18255325255555","adresa",new Account("username","password",AccountType.User)),
                    Animal = new Animal(1, "kuca", "lokacija1", "zdrav ko dren", DateTime.Now, 1, new AnimalBreed(1, "zlatni retriver", 1, new AnimalSpecies(1, "pas")),1, new Color(1,"crvena"))
                },
                new Post
                {
                    Id = 2,
                    Title = "Post 2",
                    ImageLink = "https://hipsarden-royalty-free-image-1586966191.jpg?crop=0.752xw:1.00xh;0.175xw,0&resize=1200:*",
                    Date = DateTime.Now,
                    Status = PostStatus.Active,
                    IsApproved = true,
                    AdoptionRequests = new List<AdoptionRequest>(),
                    Comments = new List<Comment>(),
                    LikedBy = new List<User>(),
                    AuthorId = 1,
                    Author = new User("pera","peric",Gender.Male,"18255325255555","adresa",new Account("username","password",AccountType.User)),
                    Animal = new Animal(2, "macka", "lokacija2", "zdrava", DateTime.Now, 2, new AnimalBreed(2, "persijska macka", 2, new AnimalSpecies(2, "macka")),1, new Color(1,"crvena"))
                },
                // Add more Post objects as needed...
            };

            List<PostViewModel> postViewModels = posts.Select(post => new PostViewModel(post)).ToList();
            _posts = new ObservableCollection<PostViewModel>(postViewModels);
            LoginRegisterCommand = new RelayCommand(LoginRegister);

        }

        public IEnumerable<PostViewModel> Posts => _posts;
        public ICommand LoginRegisterCommand { get; }
        private void LoginRegister()
        {
            var newWindow = new LoginRegisterView();
            newWindow.ShowDialog();

        }
    }
}
