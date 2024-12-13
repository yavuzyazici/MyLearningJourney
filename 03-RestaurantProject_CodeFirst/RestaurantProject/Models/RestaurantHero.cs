using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantProject.Models
{
    public class RestaurantHero
    {
        public int RestaurantHeroId { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoUrl { get; set; }
    }
}