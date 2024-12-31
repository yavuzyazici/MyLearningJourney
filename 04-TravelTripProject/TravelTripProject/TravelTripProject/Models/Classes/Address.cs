using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelTripProject.Models.Classes
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ContactAddress { get; set; }
        public string EMail { get; set; }
        public string PhoneNumber { get; set; }
        public string Location { get; set; }
    }
}