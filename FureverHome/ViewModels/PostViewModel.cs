using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FureverHome.Models;
using GalaSoft.MvvmLight;

namespace FureverHome.ViewModels
{
    public class PostViewModel : ViewModelBase
    {
        private readonly Post _post;
        public PostViewModel(Post post) {
            _post = post;    
        }
        public int Id => _post.Id;
        public string Title => _post.Title;
        public string ImageLink => _post.Title;
        public DateTime Date => _post.Date;
        public PostStatus Status => _post.Status;
        public bool IsApproved => _post.IsApproved;
        public  List<AdoptionRequest> AdoptionRequests => _post.AdoptionRequests;
        public  List<Comment> Comments => _post.Comments;
        public  List<User> LikedBy => _post.LikedBy;
        public int AuthorId => _post.AuthorId;
        public  User Author => _post.Author;
        public int AnimalId => _post.AnimalId;
        public  Animal Animal => _post.Animal;
    }

}
