using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hotel_Final.Models
{
    public class Slider
    {
        public int Id { get; set; }
        
        public int OrderBy { get; set; }
        public string Photo { get; set; }
        public string Title { get; set; }
        public  string Desc { get; set; }
        public string Actionlink { get; set; }
        public string LinkText { get; set; }
        public string ClassName { get; set; }
    }
}