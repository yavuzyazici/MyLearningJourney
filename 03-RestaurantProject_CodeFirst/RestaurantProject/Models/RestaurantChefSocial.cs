using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestaurantProject.Models
{
    public class RestaurantChefSocial
    {
        [Key]
        [Required(ErrorMessage = "Chef Social ID is required.")]
        public int RestaurantChefSocialId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "URL is required.")]
        [StringLength(500, ErrorMessage = "URL cannot exceed 500 characters.")]
        public string Url { get; set; }

        [Required(ErrorMessage = "Icon is required.")]
        [StringLength(200, ErrorMessage = "Icon cannot exceed 200 characters.")]
        public string Icon { get; set; }

        [Required(ErrorMessage = "Chef ID is required.")]
        public int RestaurantChefId { get; set; }
        public virtual RestaurantChef RestaurantChef { get; set; }
    }
}