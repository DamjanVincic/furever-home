﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FureverHome.Models
{
    public class AdoptionRequest
    {
        public int Id {  get; set; }
        public int Duration {  get; set; }
        public bool Permanent {  get; set; }
        public bool Approved {  get; set; }
        public int PostId {  get; set; }
        public Post Post { get; set; }
        public int UserId {  get; set; }
        public User User {  get; set; }
    }
}
