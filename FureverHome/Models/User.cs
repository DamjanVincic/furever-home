using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FureverHome.Models
{
    public class User
    {
        public User() { }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string Phone { get; set; }
        public string Adress {  get; set; }
        public Account Account { get; set; }
        public List<AdoptionRequest> AdoptionRequests { get; set; }
    }
}
