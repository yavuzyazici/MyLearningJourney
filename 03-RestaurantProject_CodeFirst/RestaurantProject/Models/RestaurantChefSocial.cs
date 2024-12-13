using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantProject.Models
{
    public class RestaurantChefSocial
    {
        public int RestaurantChefSocialId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public int RestaurantChefId { get; set; }
        public virtual RestaurantChef RestaurantChef { get; set; }
    }
}