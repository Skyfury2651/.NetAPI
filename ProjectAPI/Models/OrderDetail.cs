using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectAPI.Models
{
    public class OrderDetail
    {
        public int OrderDetailID { get; set; }
        public string totalPrice { get; set; }
        public string ShipperCity { get; set; }
        public Boolean IsShipped { get; set; }
        public int ProductID { get; set; }
        public int OrderID { get; set; }
        public virtual Product Product { get; set; }
        public virtual Product Order { get; set; }
    }
}