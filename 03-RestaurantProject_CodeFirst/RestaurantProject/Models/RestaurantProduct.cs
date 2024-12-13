using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace RestaurantProject.Models
{
    public class RestaurantProduct
    {
        public int RestaurantProductId { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public virtual RestaurantCategory Category { get; set; }
    }
}