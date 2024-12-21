using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RestaurantProject.Models
{
    public class RestaurantService
    {
        [Key]
        [Required(ErrorMessage = "Service ID is required.")]
        public int RestaurantServiceId { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Title must be between 2 and 100 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "Description must be between 10 and 500 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Icon is required.")]
        [StringLength(200, ErrorMessage = "Icon cannot exceed 200 characters.")]
        public string Icon { get; set; }
    }
}