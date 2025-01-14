using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DtoLayer.BannerDtos
{
    public class ResultBannerDto
    {
        [Key]
        public int BannerId { get; set; }
        [Required(ErrorMessage = "The Title field is required.")]
        [StringLength(100, ErrorMessage = "The Title must be at most 100 characters long.")]
        public required string Title { get; set; }

        [StringLength(500, ErrorMessage = "The Description must be at most 500 characters long.")]
        public required string Description { get; set; }

        [Required(ErrorMessage = "The ImageUrl field is required.")]
        public required string ImageUrl { get; set; }
    }
}
