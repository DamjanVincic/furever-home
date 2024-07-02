using FureverHome.Models;
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

        public CommentListingViewModel() {
            List<Comment> comments = new List<Comment> { new Comment(1,"username",1, new User("pera", "peric", Gender.Male, "18255325255555", "adresa", new Account("username", "password", AccountType.User))) };
            List<CommentViewModel> commentViewModels = comments.Select(comment => new CommentViewModel(comment)).ToList();
            _comments = new ObservableCollection<CommentViewModel>(commentViewModels);
        }
        public IEnumerable<CommentViewModel> Comments => _comments;

    }
}
