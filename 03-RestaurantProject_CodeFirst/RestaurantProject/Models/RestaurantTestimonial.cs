using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RestaurantProject.Models
{
    public class RestaurantTestimonial
    {
        [Key]
        [Required(ErrorMessage = "Testimonial ID is required.")]
        public int RestaurantTestimonialId { get; set; }
        [Required(ErrorMessage = "Name and Surname are required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name and Surname must be between 2 and 100 characters.")]
        public string NameSurname { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Title must be between 2 and 100 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Comment is required.")]
        [StringLength(1000, MinimumLength = 10, ErrorMessage = "Comment must be between 10 and 1000 characters.")]
        public string Comment { get; set; }

        [MaxLength(500, ErrorMessage = "Image URL cannot exceed 500 characters.")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Review score is required.")]
        [Range(1, 5, ErrorMessage = "Review must be between 1 and 5.")]
        public int Review { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}