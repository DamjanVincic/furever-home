using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FureverHome.Models;

namespace FureverHome.ViewModels
{
    public class CommentViewModel
    {
        private readonly Comment _comment;
        public CommentViewModel(Comment comment) {
            _comment = comment;
        }
        public string Text => _comment.Text;
        public string UserName => _comment.User.Account.UserName;
    }
}
