using FureverHome.Models;

namespace FureverHome.ViewModels
{
    public class CommentViewModel
    {
        private readonly Comment _comment;

        public CommentViewModel(Comment comment)
        {
            _comment = comment;
        }

        public string Text => _comment.Text;
        public string UserName => _comment.User.FirstName + " " + _comment.User.LastName;
    }
}