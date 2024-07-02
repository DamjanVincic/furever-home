﻿namespace FureverHome.Models
{
    public class Post
    {
        public Post()
        {
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageLink { get; set; }
        public DateTime Date { get; set; }
        public PostStatus Status { get; set; }
        public bool IsApproved { get; set; }
        public virtual List<AdoptionRequest> AdoptionRequests { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<User> LikedBy { get; set; }
        public int AuthorId { get; set; }
        public virtual User Author { get; set; }
        public int AnimalId { get; set; }
        public virtual Animal Animal { get; set; }
    }
}