using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FureverHome.Models
{
    public class AnimalReview
    {       
        public AnimalReview() { }
        public int Id { get; set; }

        public int Rating {  get; set; }
        public string Text { get; set; }
        public int UserId {  get; set; }
        public User User {  get; set; }
        public int AnimalId {  get; set; }
        public Animal Animal {  get; set; }
    }
}
