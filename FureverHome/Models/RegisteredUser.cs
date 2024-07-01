using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FureverHome.Models
{
    public class RegisteredUser : User
    {
        public RegisteredUser() { }
        public UserStatus Status {  get; set; }
        public int TimesReturned {  get; set; }
        public List<Message> messages { get; set; }
    }
}
