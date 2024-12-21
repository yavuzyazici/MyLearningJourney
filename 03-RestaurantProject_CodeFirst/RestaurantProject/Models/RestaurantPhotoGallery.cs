using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RestaurantProject.Models
{
    public class RestaurantPhotoGallery
    {
        [Key]
        [Required(ErrorMessage = "PhotoGallery ID is required.")]
        public int RestaurantPhotoGalleryId { get; set; }
        public string ImageUrl { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Image is required.")]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}