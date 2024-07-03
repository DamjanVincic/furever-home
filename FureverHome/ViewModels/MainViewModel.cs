using FureverHome.Models;
using FureverHome.Views;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Windows.Input;
using FureverHome.Services;

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
        }

        public IEnumerable<PostViewModel> Posts => _posts;
        public ICommand LoginCommand { get; }

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
    }
}