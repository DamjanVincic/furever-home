using System.Windows;
using System.Windows.Input;
using FureverHome.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace FureverHome.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly Window _loginWindow;

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
            //User? user = _userService.Login(Username!, Password!);

            //switch (user)
            //{
            //    case null:
            //        MessageBox.Show("Invalid username or password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //        return;

            //    case Student student:
            //        _studentService.CheckIfFirstInMonth();
            //        ReviewTeacher(student);

            //        new StudentView().Show();
            //        break;
            //    case Director:
            //        new DirectorMainMenu().Show();
            //        break;
            //    case Teacher:
            //        new TeacherMenu().Show();
            //        break;
            //}

            _loginWindow.Close();
            Application.Current.MainWindow?.Close();
        }

    }
}
