using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace FureverHome.ViewModels
{
    public class AdoptionPeriodViewModel : INotifyPropertyChanged
    {
        private int _adoptionPeriod;
        private bool _isPermanent;

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

        public AdoptionPeriodViewModel()
        {
            SubmitCommand = new RelayCommand(Submit);
        }

        private void Submit()
        {
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
