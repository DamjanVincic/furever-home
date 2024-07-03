using FureverHome.Models;
using FureverHome.Services;
using FureverHome.Views;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace FureverHome.ViewModels
{
    public class CommentListingViewModel
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
        }

        public IEnumerable<CommentViewModel> Comments => _comments;
        public ICommand AddCommentCommand { get; }
        private void AddComment()
        {
            var window = new AddCommentView(_postId,UserService.LoggedInAccount.User.Id);
            window.Show();
        }
    }

}