using FureverHome.Models;
using FureverHome.Services;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace FureverHome.ViewModels
{
    internal class RegistrationRequestViewModel : ViewModelBase
    {
        private readonly RegisteredUser _user;
        public RegistrationRequestViewModel(RegisteredUser user)
        {
            _user = user;
        }

        public int Id => _user.Id;
        public string FirstName => _user.FirstName;
        public string LastName => _user.LastName;
        public string Adress => _user.Adress;
        public Gender Gender => _user.Gender;
        public string Phone => _user.Phone;
    }
}
