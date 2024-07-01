using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FureverHome.Models
{
    public class Donation
    {
        public Donation() { }
        public double Amount {  get; set; }
        public bool Anonymous {  get; set; }
        public string User { get; set; }
        public string Description { get; set; }
    }
}
