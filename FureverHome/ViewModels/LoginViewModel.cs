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
            _loginWindow.Close();
        }
        private void Login()
        {
            try{
                Account? account = _userService.Login(Username!, Password!);
                //Application.Current.MainWindow?.Close();
                if (account == null) {
                    MessageBox.Show("invalid username or password.", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else if (account.Type.Equals(AccountType.Volunteer)){
                    //new VolunteerView().Show();
                    _loginWindow.Close();
                }
                else {
                    new MainWindowUser().Show();
                    _loginWindow.Close();
                }

            }
            catch (InvalidInputException e)
            {
                MessageBox.Show(e.Message, "error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "error", MessageBoxButton.OK, MessageBoxImage.Error);
                _loginWindow.Close();

            }
        }

    }
}
