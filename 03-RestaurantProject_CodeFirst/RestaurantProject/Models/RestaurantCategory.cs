using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantProject.Models
{
    public class RestaurantCategory
    {
        public int RestaurantCategoryId { get; set; }
        public string CategoryName { get; set; }
        public virtual List<RestaurantProduct> Products { get; set; }
    }
}