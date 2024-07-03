using FureverHome.Models;
using FureverHome.Services;
using FureverHome.Views;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace FureverHome.ViewModels
{
    public class CommentListingViewModel : INotifyPropertyChanged
    {
        private readonly ObservableCollection<CommentViewModel> _comments;
        private readonly CommentService _commentService = ServiceProvider.GetRequiredService<CommentService>();
        private readonly int _postId;

        public CommentListingViewModel(int postId)
        {
            _postId = postId;
            _comments = new ObservableCollection<CommentViewModel>(_commentService.GetByPostId(postId)
                .Select(comment => new CommentViewModel(comment)));

            AddCommentCommand = new RelayCommand(AddComment);
            RefreshCommentsCommand = new RelayCommand(RefreshComments);
            CommentsCollectionView = CollectionViewSource.GetDefaultView(_comments);
        }

        public IEnumerable<CommentViewModel> Comments => _comments;
        public ICommand AddCommentCommand { get; }
        public ICommand RefreshCommentsCommand { get; }
        public ICollectionView CommentsCollectionView { get; }

        private void AddComment()
        {
            if(UserService.LoggedInAccount == null)
            {
                MessageBox.Show("You must login to comment.", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }
            var window = new AddCommentView(_postId, UserService.LoggedInAccount.User.Id);
            window.ShowDialog(); 
            RefreshComments(); 
        }

        private void RefreshComments()
        {
            _comments.Clear();
            _commentService.GetByPostId(_postId).ForEach(comment => _comments.Add(new CommentViewModel(comment)));
            CommentsCollectionView.Refresh();
            OnPropertyChanged(nameof(Comments));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}