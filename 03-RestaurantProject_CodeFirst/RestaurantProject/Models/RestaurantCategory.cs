using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestaurantProject.Models
{
    public class RestaurantCategory
    {
        [Key]
        [Required(ErrorMessage = "Category ID is required.")]
        public int RestaurantCategoryId { get; set; }
        [Required(ErrorMessage = "Category Name is required.")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "Category Name must be between 2 and 200 characters.")]
        public string CategoryName { get; set; }
        public virtual List<RestaurantProduct> Products { get; set; }
    }
}