using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using FureverHome.Models;
using FureverHome.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace FureverHome.ViewModels;

public class AdoptionRequestListingViewModel : ViewModelBase
{
    private readonly AdoptionService _adoptionService;
    
    public ObservableCollection<AdoptionRequestViewModel> AdoptionRequests { get; set; }
    public ICollectionView AdoptionRequestsCollectionView { get; set; }
    public AdoptionRequestViewModel SelectedAdoptionRequest { get; set; }

    public AdoptionRequestListingViewModel(AdoptionService adoptionService)
    {
        _adoptionService = adoptionService;

        AdoptionRequests = new ObservableCollection<AdoptionRequestViewModel>();
        AdoptionRequestsCollectionView = CollectionViewSource.GetDefaultView(AdoptionRequests);

        ApproveCommand = new RelayCommand(Approve);
        RejectCommand = new RelayCommand(Reject);

        RefreshRequests();
    }

    public ICommand ApproveCommand { get; }
    public ICommand RejectCommand { get; }

    private void RefreshRequests()
    {
        AdoptionRequests.Clear();
        _adoptionService.GetUnapproved().ForEach(adoptionRequest => AdoptionRequests.Add(new AdoptionRequestViewModel(adoptionRequest)));
        AdoptionRequestsCollectionView.Refresh();
    }

    private void Approve()
    {
        try
        {
            if (SelectedAdoptionRequest is null)
                throw new InvalidInputException("No adoption request selected");
            
            _adoptionService.ReviewRequest(SelectedAdoptionRequest.Id, true);
            MessageBox.Show("Post approved successfully.", "Success", MessageBoxButton.OK,
                MessageBoxImage.Information);

            RefreshRequests();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void Reject()
    {
        try
        {
            if (SelectedAdoptionRequest is null)
                throw new InvalidInputException("No adoption request selected");
            
            _adoptionService.ReviewRequest(SelectedAdoptionRequest.Id, false);
            MessageBox.Show("Post approved successfully.", "Success", MessageBoxButton.OK,
                MessageBoxImage.Information);

            RefreshRequests();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}