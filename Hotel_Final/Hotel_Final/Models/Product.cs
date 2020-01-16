using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel_Final.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int OrderBy { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public int Price { get; set; }
        public int ProductCount { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}