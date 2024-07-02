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
using FureverHome.Services;

namespace FureverHome.ViewModels
{
    public class MainViewModel
    {
        private readonly ObservableCollection<PostViewModel> _posts;

        private readonly PostService _postService = ServiceProvider.GetRequiredService<PostService>();
        public MainViewModel()
        {
            _posts = new ObservableCollection<PostViewModel>(_postService.GetAll().Select(post=>new PostViewModel(post)));
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
