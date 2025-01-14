using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DtoLayer.AboutDtos
{
    public class ResultAboutDto
    {
        [Key]
        public int AboutId { get; set; }
        [Required(ErrorMessage = "The Mission field is required.")]
        [StringLength(500, ErrorMessage = "The Mission must be at most 500 characters long.")]
        public required string Mission { get; set; }

        [Required(ErrorMessage = "The Vision field is required.")]
        [StringLength(500, ErrorMessage = "The Vision must be at most 500 characters long.")]
        public required string Vision { get; set; }
    }
}
