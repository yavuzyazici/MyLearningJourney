using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantProject.Models
{
    public class RestaurantTestimonial
    {
        public int RestaurantTestimonialId { get; set; }
        public string NameSurname { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public string ImageUrl { get; set; }
        public int Review { get; set; }
    }
}