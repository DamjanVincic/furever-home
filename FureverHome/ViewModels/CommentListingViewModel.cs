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
        private readonly ICommentService _commentService;

        public CommentListingViewModel(ICommentService commentService,int postId) {
            _commentService = commentService;
            _comments = new ObservableCollection<CommentViewModel>(_commentService.GetByPostId(postId).Select(comment => new CommentViewModel(comment)));
        }
        public IEnumerable<CommentViewModel> Comments => _comments;

    }
}
