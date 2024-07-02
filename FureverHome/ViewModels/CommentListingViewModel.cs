using FureverHome.Models;
using FureverHome.Services;
using System.Collections.ObjectModel;

namespace FureverHome.ViewModels
{
    public class CommentListingViewModel
    {
        private readonly ObservableCollection<CommentViewModel> _comments;
        private readonly CommentService _commentService = ServiceProvider.GetRequiredService<CommentService>();

        public CommentListingViewModel(int postId)
        {
            _comments = new ObservableCollection<CommentViewModel>(_commentService.GetByPostId(postId)
                .Select(comment => new CommentViewModel(comment)));
        }

        public IEnumerable<CommentViewModel> Comments => _comments;
    }
}