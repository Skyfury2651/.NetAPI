using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectAPI.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public Boolean Status { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}