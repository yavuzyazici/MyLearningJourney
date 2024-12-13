using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantProject.Models
{
    public class RestaurantContactInfo
    {
        public int RestaurantContactInfoId { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PlaceName { get; set; }
        public string MapUrl { get; set; }
        public string OpenHours { get; set; }
    }
}