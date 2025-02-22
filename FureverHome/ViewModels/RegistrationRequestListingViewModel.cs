﻿using FureverHome.Services;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows;
using GalaSoft.MvvmLight.Command;
using FureverHome.Models;

namespace FureverHome.ViewModels
{
    internal class RegistrationRequestListingViewModel: ViewModelBase
    {

        private readonly User _user = UserService.LoggedInAccount!.User ??
                                            throw new InvalidOperationException("No one is logged in.");
        

        private readonly ObservableCollection<RegistrationRequestViewModel> _registrationRequests;
        private readonly UserService _userService = ServiceProvider.GetRequiredService<UserService>();
        private readonly VolunteerService _volunteerService = ServiceProvider.GetRequiredService<VolunteerService>();


        public RegistrationRequestListingViewModel()
        {
            _registrationRequests = new ObservableCollection<RegistrationRequestViewModel>(_userService.GetPendingUsers()
                .Select(user => new RegistrationRequestViewModel(user)));
            RegistrationRequestsCollectionView = CollectionViewSource.GetDefaultView(_registrationRequests);
            ApproveCommand = new RelayCommand(Approve);
            RejectCommand = new RelayCommand(Reject);
        }


        public RegistrationRequestViewModel? SelectedItem { get; set; }

        public ICollectionView RegistrationRequestsCollectionView { get; }
        public IEnumerable<RegistrationRequestViewModel> RegistrationRequests => _registrationRequests;

        public ICommand ApproveCommand { get; }
        public ICommand RejectCommand { get; }

        private void Approve()
        {
            if (SelectedItem == null)
            {
                MessageBox.Show("Please select a request.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                _volunteerService.ApproveRegistrationRequest(SelectedItem.Id);
                MessageBox.Show("Request is approved.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                RefreshRegistrationRequests();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Reject()
        {
            if (SelectedItem == null)
            {
                MessageBox.Show("Please select a request.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try {
                _volunteerService.RejectRegistrationRequest(SelectedItem.Id);
            MessageBox.Show("Request is rejected.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                RefreshRegistrationRequests();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RefreshRegistrationRequests()
        {
            _registrationRequests.Clear();
            _userService.GetPendingUsers().ForEach(user => _registrationRequests.Add(new RegistrationRequestViewModel(user)));
            RegistrationRequestsCollectionView.Refresh();
        }

    }
}
