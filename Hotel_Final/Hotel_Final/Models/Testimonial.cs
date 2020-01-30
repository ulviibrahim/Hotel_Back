using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel_Final.Models
{
    public class Testimonial
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public string Context { get; set; }
        public int Rate { get; set; }
        public DateTime Date { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}