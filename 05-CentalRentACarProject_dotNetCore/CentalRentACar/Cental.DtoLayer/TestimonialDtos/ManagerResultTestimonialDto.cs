using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DtoLayer.TestimonialDtos
{
    public class ManagerResultTestimonialDto
    {
        [Key]
        public int TestimonialId { get; set; }

        [Required(ErrorMessage = "The ImageUrl field is required.")]
        public required string ImageUrl { get; set; }

        [Required(ErrorMessage = "The NameSurname field is required.")]
        [StringLength(100, ErrorMessage = "The NameSurname must be at most 100 characters long.")]
        public required string NameSurname { get; set; }

        [Required(ErrorMessage = "The Job Title field is required.")]
        [StringLength(100, ErrorMessage = "The Job Title must be at most 100 characters long.")]
        public required string JobTitle { get; set; }
        [Required(ErrorMessage = "The Review field is required.")]
        [Range(0, 5, ErrorMessage = "The Review must be 0-5.")]
        public int Review { get; set; }
        [Required(ErrorMessage = "The Comment field is required.")]
        [StringLength(500, ErrorMessage = "The Comment must be at most 500 characters long.")]
        public required string Comment { get; set; }
        public bool IsAproved { get; set; }
        public int UserId { get; set; }
    }
}
