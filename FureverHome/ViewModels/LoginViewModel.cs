using System.Windows;
using System.Windows.Input;
using FureverHome.Models;
using FureverHome.Services;
using FureverHome.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace FureverHome.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly Window _loginWindow;

        private readonly UserService _userService = ServiceProvider.GetRequiredService<UserService>();
        public string? Username { get; set; }
        public string? Password { get; set; }

        public ICommand LoginCommand { get; }
        public ICommand NavigateToRegisterCommand { get; }

        public LoginViewModel(Window loginWindow)
        {
            _loginWindow = loginWindow;
            NavigateToRegisterCommand = new RelayCommand(NavigateToRegister);
            LoginCommand = new RelayCommand(Login);
        }

        private void NavigateToRegister()
        {
            new RegisterView().Show();
        }
        private void Login()
        {
            try{
                User? user = _userService.Login(Username!, Password!);
            }
            catch(InvalidOperationException e)
            {
                MessageBox.Show(e.Message, "error", MessageBoxButton.OK, MessageBoxImage.Error);

            }

            //switch (user)
            //{
            //    case null:
            //        messagebox.show("invalid username or password.", "error", messageboxbutton.ok, messageboximage.error);
            //        return;

            //    case student student:
            //        _studentservice.checkiffirstinmonth();
            //        reviewteacher(student);

            //        new studentview().show();
            //        break;
            //    case director:
            //        new directormainmenu().show();
            //        break;
            //    case teacher:
            //        new teachermenu().show();
            //        break;
            //}

            _loginWindow.Close();
            Application.Current.MainWindow?.Close();
        }

    }
}
