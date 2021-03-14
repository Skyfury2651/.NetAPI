using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectAPI.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string name { get; set; }
        public int? CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}