using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantProject.Models
{
    public class RestaurantChef
    {
        public int RestaurantChefId { get; set; }
        public string NameSurname { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public virtual List<RestaurantChefSocial> RestaurantChefSocials { get; set; }
    }
}