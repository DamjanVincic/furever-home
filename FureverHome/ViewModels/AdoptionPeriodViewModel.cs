using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using FureverHome.Models;
using FureverHome.Services;
using GalaSoft.MvvmLight.Command;

namespace FureverHome.ViewModels
{
    public class AdoptionPeriodViewModel : INotifyPropertyChanged
    {
        private int _adoptionPeriod;
        private bool _isPermanent;
        private readonly UserService _userService = ServiceProvider.GetRequiredService<UserService>();
        private readonly AdoptionService _adoptionService = ServiceProvider.GetRequiredService<AdoptionService>();
        private readonly int _postId;
        public AdoptionPeriodViewModel(int postId)
        {
            _postId = postId;
            SubmitCommand = new RelayCommand(Submit);

        }

        public int AdoptionPeriod
        {
            get => _adoptionPeriod;
            set
            {
                if (_adoptionPeriod != value)
                {
                    _adoptionPeriod = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsPermanent
        {
            get => _isPermanent;
            set
            {
                if (_isPermanent != value)
                {
                    _isPermanent = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(IsInputEnabled));
                }
            }
        }

        public bool IsInputEnabled => !IsPermanent;

        public ICommand SubmitCommand { get; }


        private void Submit()
        {
            try
            {
                _adoptionService.Add(_postId, UserService.LoggedInAccount.UserId, AdoptionPeriod, IsPermanent);
                MessageBox.Show("Request for adoption sent successfully.", "Success", MessageBoxButton.OK,
              MessageBoxImage.Information);
            }
            catch(InvalidInputException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
