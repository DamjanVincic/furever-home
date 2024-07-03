using FureverHome.Models;
using FureverHome.Views;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Windows.Input;
using FureverHome.Services;
using System.Security.RightsManagement;

namespace FureverHome.ViewModels
{
    public class MainViewModel
    {
        private readonly ObservableCollection<PostViewModel> _posts;

        private readonly PostService _postService = ServiceProvider.GetRequiredService<PostService>();

        public MainViewModel()
        {
            _posts = new ObservableCollection<PostViewModel>(_postService.GetAll().Select(post => new PostViewModel(post)));
            
            LoginCommand = new RelayCommand(Login);
            RegistrationCommand = new RelayCommand(ViewregistrationRequests);
            CreatePostCommand = new RelayCommand(CreatePost);
            LogoutCommand = new RelayCommand(Logout);
        }

        public IEnumerable<PostViewModel> Posts => _posts;
        public ICommand LoginCommand { get; }
        public ICommand CreatePostCommand { get; }
        public ICommand LogoutCommand { get; }

        private void Login()
        {
            var newWindow = new LoginView();
            newWindow.ShowDialog();
        }
        public ICommand RegistrationCommand { get; }
        private void ViewregistrationRequests()
        {
            var newWindow = new RegistrationRequestListingView();
            newWindow.ShowDialog();

        }
        private void CreatePost()
        {
            var window = new AddPostView();
            window.ShowDialog();
        }
        private void Logout()
        {
            UserService.LoggedInAccount = null;
            var mainWindow = new MainWindow();
            mainWindow.Show();
            foreach (Window window in Application.Current.Windows)
            {
                if (window != mainWindow)
                {
                    window.Close();
                }
            }
        }
        }
}