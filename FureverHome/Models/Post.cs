using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FureverHome.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageLink { get; set; }
        public DateTime Date { get; set; }
        public PostStatus Status {  get; set; }
        public bool IsApproved {  get; set; }
        public List<AdoptionRequest> AdoptionRequests { get; set; }
        public List<Comment> Comments { get; set; }
        public List<User> Users { get; set; }
        public int AuthorId {  get; set; }
        public User Author {  get; set; }
        public int AnimalId {  get; set; }
        public Animal Animal {  get; set; }
    }
}
