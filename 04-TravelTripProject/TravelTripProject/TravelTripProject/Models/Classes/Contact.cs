using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelTripProject.Models.Classes
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        public string NameSurname { get; set; }
        public string EMail { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}