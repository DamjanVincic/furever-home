using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FureverHome.Models
{
    public class VolunteerApplication : User
    {
        public int Id {  get; set; }
        public List<Volunteer> YesVotes { get; set; }
        public List<Volunteer> NoVotes { get; set; }
        public int AuthorId {  get; set; }
        public Volunteer Author { get; set; }
        public int RegisteredUserId {  get; set; }
        public RegisteredUser RegisteredUser { get; set; }
    }
}
