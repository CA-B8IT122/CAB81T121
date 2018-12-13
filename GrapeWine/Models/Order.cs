using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GrapeWine.Models
{
    public class Order
    {
        public int ProductID { get; set; }
        public int CustomerID { get; set; }
        public string ProductType { get; set; }
        public string ProductName { get; set; }
        public string Country { get; set; }
        public string Grape { get; set; }
        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}