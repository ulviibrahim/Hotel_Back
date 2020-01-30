using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Hotel_Final.Models
{
    public class OrderHistory
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ApplicationUserId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int OrderCount { get; set; } = 1;
        public bool isDeleted { get; set; } = false;
        public int TotalPrice { get; set; }
        public virtual  Product Product { get; set; }

        [ForeignKey("ApplicationUserId")]
        public virtual  ApplicationUser ApplicationUser { get; set; }
    }
}