using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace RestaurantProject.Models
{
    public class RestaurantAbout
    {
        [Key]
        [Required(ErrorMessage = "About ID is required.")]
        public int RestaurantAboutId { get; set; }

        [Required(ErrorMessage = "Image URL is required.")]
        [MaxLength(500, ErrorMessage = "Image URL cannot exceed 500 characters.")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Item1 is required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Item1 must be between 3 and 100 characters.")]
        public string Item1 { get; set; }

        [Required(ErrorMessage = "Item2 is required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Item2 must be between 3 and 100 characters.")]
        public string Item2 { get; set; }

        [Required(ErrorMessage = "Item3 is required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Item3 must be between 3 and 100 characters.")]
        public string Item3 { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(1000, MinimumLength = 10, ErrorMessage = "Description must be between 10 and 1000 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Video URL is required.")]
        [MaxLength(500, ErrorMessage = "Video URL cannot exceed 500 characters.")]
        public string VideoUrl { get; set; }

        [Required(ErrorMessage = "Video Image URL is required.")]
        [MaxLength(500, ErrorMessage = "Video Image URL cannot exceed 500 characters.")]
        public string VideoImageUrl { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [StringLength(15, MinimumLength = 10, ErrorMessage = "Phone number must be between 10 and 15 characters.")]
        public string Phone { get; set; }


        [NotMapped]
        public HttpPostedFileBase AboutImage { get; set; }

        [NotMapped]
        public HttpPostedFileBase VideoImage { get; set; }
    }
}