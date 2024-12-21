using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RestaurantProject.Models
{
    public class RestaurantProduct
    {
        [Key]
        [Required(ErrorMessage = "Product ID is required.")]
        public int RestaurantProductId { get; set; }

        //[Required(ErrorMessage = "Image URL is required.")]
        [MaxLength(500, ErrorMessage = "Image URL cannot exceed 500 characters.")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "Description must be between 10 and 500 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, 10000.00, ErrorMessage = "Price must be between 0.01 and 10,000.00.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Category ID is required.")]
        public int RestaurantCategoryId { get; set; }
        public virtual RestaurantCategory RestaurantCategory { get; set; }

        [NotMapped]
        public HttpPostedFileBase ProductImage { get; set; }
    }
}