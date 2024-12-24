using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestaurantProject.Models
{
    public class RestaurantSocialMedia
    {
        [Key]
        public int RestaurantSocialMediaId { get; set; }
        [Required(ErrorMessage = "The URL field is required.")]
        [Url(ErrorMessage = "Please enter a valid URL.")]
        [StringLength(500, ErrorMessage = "The URL cannot exceed 500 characters.")]
        public string Url { get; set; }

        [Required(ErrorMessage = "The Icon field is required.")]
        [StringLength(50, ErrorMessage = "The Icon cannot exceed 50 characters.")]
        public string Icon { get; set; }
    }
}