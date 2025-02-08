using Cental.EntityLayer.Entities;
using Cental.EntityLayer.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DtoLayer.CarDtos
{
    public class CreateCarDto
    {
        [Key]
        public int CarId { get; set; }
        public required string ModelName { get; set; }
        public string? ImageUrl { get; set; }
        public IFormFile? ImageFile { get; set; }
        public required decimal Price { get; set; }
        public required int SeatCount { get; set; }
        public required string GearType { get; set; }
        public required string FuelType { get; set; }
        public int Year { get; set; }
        public required string Transmission { get; set; }
        public int Kilometer { get; set; }
        public int BrandId { get; set; }
    }
}
