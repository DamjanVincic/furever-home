using FureverHome.Models;
using FureverHome.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FureverHome.ViewModels
{
    public class CommentListingViewModel
    {
        private readonly ObservableCollection<CommentViewModel> _comments;
        private readonly CommentService _commentService = ServiceProvider.GetRequiredService<CommentService>();

        public CommentListingViewModel(int postId) {
            _comments = new ObservableCollection<CommentViewModel>(_commentService.GetByPostId(postId).Select(comment => new CommentViewModel(comment)));
        }
        public IEnumerable<CommentViewModel> Comments => _comments;

    }
}
