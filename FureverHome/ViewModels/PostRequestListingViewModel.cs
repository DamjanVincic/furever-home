using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Xml.Serialization;
using FureverHome.Models;
using FureverHome.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace FureverHome.ViewModels
{
    internal class PostRequestListingViewModel:ViewModelBase
    {
        private readonly PostService _postService;
        public ObservableCollection<PostRequestViewModel> PostRequests { get; set; }
        public ICollectionView PostRequestsCollectionView { get; set; }
        public PostRequestViewModel SelectedPostRequest { get; set; }

        public PostRequestListingViewModel(PostService postService)
        {
            _postService = postService;

            PostRequests=new ObservableCollection<PostRequestViewModel>();
            PostRequestsCollectionView = CollectionViewSource.GetDefaultView(PostRequests);

            ApproveCommand = new RelayCommand(Approve);
            RejectCommand = new RelayCommand(Reject);

            refreshRequests();
        }

        public ICommand ApproveCommand { get; }
        public ICommand RejectCommand { get; }

        private void refreshRequests()
        {
            PostRequests.Clear();
            _postService.GetUnapproved().ForEach(post => PostRequests.Add(new PostRequestViewModel(post)));
            PostRequestsCollectionView.Refresh();
        }

        private void Approve()
        {
            try
            {
                if (SelectedPostRequest == null)
                    throw new InvalidInputException("No post request selected");
                _postService.SubmitReview(SelectedPostRequest.Id,true);
                MessageBox.Show("Post approved successfully.", "Success", MessageBoxButton.OK,
                    MessageBoxImage.Information);
                refreshRequests();
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
                if (SelectedPostRequest == null)
                    throw new InvalidInputException("No post request selected");
                _postService.SubmitReview(SelectedPostRequest.Id, false);
                MessageBox.Show("Post rejected successfully.", "Success", MessageBoxButton.OK,
                    MessageBoxImage.Information);
                refreshRequests();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
