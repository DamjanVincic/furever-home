﻿namespace FureverHome.Models
{
    public class Comment
    {
        public Comment()
        {
        }

        public int Id { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}