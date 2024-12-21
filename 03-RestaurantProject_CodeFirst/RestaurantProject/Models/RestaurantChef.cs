using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RestaurantProject.Models
{
    public class RestaurantChef
    {
        [Key]
        [Required(ErrorMessage = "Chef ID is required.")]
        public int RestaurantChefId { get; set; }

        [Required(ErrorMessage = "Name and Surname are required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name and Surname must be between 2 and 100 characters.")]
        public string NameSurname { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Title must be between 2 and 100 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "Description must be between 10 and 500 characters.")]
        public string Description { get; set; }

        [StringLength(500, ErrorMessage = "Image URL cannot exceed 500 characters.")]
        public string ImageUrl { get; set; }
        public virtual List<RestaurantChefSocial> RestaurantChefSocials { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}