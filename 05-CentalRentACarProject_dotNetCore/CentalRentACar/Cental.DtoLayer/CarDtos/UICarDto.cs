using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DtoLayer.CarDtos
{
    public class UICarDto
    {
        [Key]
        public int CarId { get; set; }
        public required string ModelName { get; set; }
        public required string ImageUrl { get; set; }
        public required decimal Price { get; set; }
        public required int SeatCount { get; set; }
        public required string GearType { get; set; }
        public required string FuelType { get; set; }
        public int Year { get; set; }
        public required string Transmission { get; set; }
        public required string Kilometer { get; set; }
        public required Brand Brand { get; set; }
        public List<Review>? Reviews { get; set; }
    }
}
