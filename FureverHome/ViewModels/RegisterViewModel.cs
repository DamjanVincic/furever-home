using FureverHome.Models;
using GalaSoft.MvvmLight;
using System.Windows.Input;
using System.Windows;
using GalaSoft.MvvmLight.Command;
using FureverHome.Services;

namespace FureverHome.ViewModels
{
    internal class RegisterViewModel : ViewModelBase
    {
        private readonly UserService _userService = ServiceProvider.GetRequiredService<UserService>();
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public Gender Gender { get; set; }
        public string? Phone { get; set; }
        public string? Adress { get; set; }
        public IEnumerable<Gender> GenderValues => Enum.GetValues(typeof(Gender)).Cast<Gender>();
        public ICommand RegisterCommand { get; }

        private readonly Window _registerWindow;

        public RegisterViewModel(Window registerWindow)
        {
            _registerWindow = registerWindow;
            RegisterCommand = new RelayCommand(Register);
        }

        private void Register()
        {
            try
            {
                _userService.Add(FirstName!, LastName!, Username!, Password!, Gender, Phone!, Adress);

                MessageBox.Show("User registered successfully.", "Success", MessageBoxButton.OK,
                    MessageBoxImage.Information);

                _userService.Login(Username!, Password!);

                //new StudentView().Show();
                _registerWindow.Close();
                Application.Current.MainWindow?.Close();
            }
            catch (InvalidInputException exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (ArgumentNullException exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
