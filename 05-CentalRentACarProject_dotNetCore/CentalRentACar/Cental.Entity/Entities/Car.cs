using Cental.EntityLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.EntityLayer.Entities
{
    public class Car
    {
        [Key]
        public int CarId { get; set; }

        [Required(ErrorMessage = "The Model Name is required.")]
        [StringLength(100, ErrorMessage = "The Model Name must be at most 100 characters long.")]
        public required string ModelName { get; set; }

        [Required(ErrorMessage = "The Image URL is required.")]
        public required string ImageUrl { get; set; }

        [Required(ErrorMessage = "The Price is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "The Price must be a positive value.")]
        public required decimal Price { get; set; }

        [Required(ErrorMessage = "The Seat Count is required.")]
        [Range(1, 20, ErrorMessage = "The Seat Count must be between 1 and 20.")]
        public required int SeatCount { get; set; }

        [Required(ErrorMessage = "The Gear Type is required.")]
        [StringLength(50, ErrorMessage = "The Gear Type must be at most 50 characters long.")]
        public required string GearType { get; set; }

        [Required(ErrorMessage = "The Fuel Type is required.")]
        [StringLength(50, ErrorMessage = "The Fuel Type must be at most 50 characters long.")]
        public required string FuelType { get; set; }

        [Required(ErrorMessage = "The Year is required.")]
        [Range(1886, 2100, ErrorMessage = "The Year must be between 1886 and 2100.")]
        public int Year { get; set; }

        [Required(ErrorMessage = "The Transmission is required.")]
        [StringLength(50, ErrorMessage = "The Transmission must be at most 50 characters long.")]
        public required string Transmission { get; set; }

        [Required(ErrorMessage = "The Kilometer value is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "The Kilometer must be a positive value.")]
        public int Kilometer { get; set; }

        [Required(ErrorMessage = "The Brand ID is required.")]
        public int BrandId { get; set; }
        public virtual required Brand Brand { get; set; }
        public virtual List<Review>? Reviews { get; set; }
    }
}
