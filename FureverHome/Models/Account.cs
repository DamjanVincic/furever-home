﻿namespace FureverHome.Models
{
    public class Account
    {
        public Account()
        {
        }
        
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int RegisteredUserId { get; set; }
        public virtual RegisteredUser RegisteredUser { get; set; }
        public AccountType Type { get; set; }
        public AccountStatus Status { get; set; }
    }
}