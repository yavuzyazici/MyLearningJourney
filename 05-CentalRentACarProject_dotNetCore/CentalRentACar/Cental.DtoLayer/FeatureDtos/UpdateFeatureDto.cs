using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DtoLayer.FeatureDtos
{
    public class UpdateFeatureDto
    {
        [Key]
        public int FeatureId { get; set; }
        [Required(ErrorMessage = "The Title field is required.")]
        [StringLength(200, ErrorMessage = "The Title must be at most 200 characters long.")]
        public required string Title { get; set; }

        [Required(ErrorMessage = "The Description field is required.")]
        [StringLength(500, ErrorMessage = "The Description must be at most 500 characters long.")]
        public required string Description { get; set; }

        [Required(ErrorMessage = "The Icon field is required.")]
        public required string Icon { get; set; }
    }
}
