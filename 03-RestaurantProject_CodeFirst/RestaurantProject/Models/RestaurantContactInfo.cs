using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestaurantProject.Models
{
    public class RestaurantContactInfo
    {
        [Key]
        [Required(ErrorMessage = "Contact Info ID is required.")]
        public int RestaurantContactInfoId { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(300, MinimumLength = 10, ErrorMessage = "Address must be between 10 and 300 characters.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        [StringLength(200, ErrorMessage = "Email cannot exceed 200 characters.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [StringLength(15, MinimumLength = 10, ErrorMessage = "Phone number must be between 10 and 15 characters.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Map URL is required.")]
        [StringLength(500, ErrorMessage = "Map URL cannot exceed 500 characters.")]
        public string MapUrl { get; set; }

        [Required(ErrorMessage = "Open hours information is required.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Open hours must be between 5 and 100 characters.")]
        public string OpenHours { get; set; }
    }
}