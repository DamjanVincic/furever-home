using FureverHome.ViewModels;
using System.Windows;

namespace FureverHome.Views
{
    public partial class RegisterView : Window
    {
        public RegisterView()
        {
            InitializeComponent();
            DataContext = new RegisterViewModel(this);
        }
    }
}
