using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RestaurantProject.Models
{
    public class RestaurantHero
    {
        [Key]
        [Required(ErrorMessage = "Hero ID is required.")]
        public int RestaurantHeroId { get; set; }

        [Required(ErrorMessage = "Image URL is required.")]
        [StringLength(500, ErrorMessage = "Image URL cannot exceed 500 characters.")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Title must be between 2 and 100 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "Description must be between 10 and 500 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Video URL is required.")]
        [StringLength(500, ErrorMessage = "Video URL cannot exceed 500 characters.")]
        public string VideoUrl { get; set; }

        [NotMapped]
        public HttpPostedFileBase HeroImage { get; set; }
    }
}