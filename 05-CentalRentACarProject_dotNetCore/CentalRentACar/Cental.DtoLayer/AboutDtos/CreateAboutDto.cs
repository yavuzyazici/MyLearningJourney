using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DtoLayer.AboutDtos
{
    public class CreateAboutDto
    {
        [Required(ErrorMessage = "The Mission field is required.")]
        [StringLength(500, ErrorMessage = "The Mission must be at most 500 characters long.")]
        public required string Mission { get; set; }

        [Required(ErrorMessage = "The Vision field is required.")]
        [StringLength(500, ErrorMessage = "The Vision must be at most 500 characters long.")]
        public required string Vision { get; set; }

        [Required(ErrorMessage = "The Description1 field is required.")]
        [StringLength(300, ErrorMessage = "The Description1 must be at most 300 characters long.")]
        public required string Description1 { get; set; }

        [Required(ErrorMessage = "The Description2 field is required.")]
        [StringLength(300, ErrorMessage = "The Description2 must be at most 300 characters long.")]
        public required string Description2 { get; set; }

        [Required(ErrorMessage = "The StartYear field is required.")]
        [Range(1800, 2200, ErrorMessage = "The StartYear must be between 1900 and 2100.")]
        public int StartYear { get; set; }

        [Required(ErrorMessage = "The ImageUrlBig field is required.")]
        public required string ImageUrlBig { get; set; }

        [Required(ErrorMessage = "The ImageUrlSmall field is required.")]
        public required string ImageUrlSmall { get; set; }

        [Required(ErrorMessage = "The Item1 field is required.")]
        [StringLength(200, ErrorMessage = "The Item1 must be at most 200 characters long.")]
        public required string Item1 { get; set; }

        [Required(ErrorMessage = "The Item2 field is required.")]
        [StringLength(200, ErrorMessage = "The Item2 must be at most 200 characters long.")]
        public required string Item2 { get; set; }

        [Required(ErrorMessage = "The Item3 field is required.")]
        [StringLength(200, ErrorMessage = "The Item3 must be at most 200 characters long.")]
        public required string Item3 { get; set; }

        [Required(ErrorMessage = "The Item4 field is required.")]
        [StringLength(200, ErrorMessage = "The Item4 must be at most 200 characters long.")]
        public required string Item4 { get; set; }

        [Required(ErrorMessage = "The NameSurname field is required.")]
        [StringLength(100, ErrorMessage = "The NameSurname must be at most 100 characters long.")]
        public required string NameSurname { get; set; }

        [Required(ErrorMessage = "The JobTitle field is required.")]
        [StringLength(100, ErrorMessage = "The JobTitle must be at most 100 characters long.")]
        public required string JobTitle { get; set; }

        [Required(ErrorMessage = "The ProfilePictureUrl field is required.")]
        public required string ProfilePictureUrl { get; set; }
    }
}
