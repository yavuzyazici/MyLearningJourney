using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantProject.Models
{
    public class RestaurantBooking
    {
        public int RestaurantBookingId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime BookingDate { get; set; }
        public int PersonCount { get; set; }
        public string MessageContent { get; set; }
        public bool IsApproved { get; set; }
    }
}