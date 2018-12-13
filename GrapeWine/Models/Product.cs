using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GrapeWine.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductType { get; set; }
        public string ProductCountry { get; set; }
        public string Grape { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal Price { get; set; }
        public string ImageSrc { get; set; }
    }
}