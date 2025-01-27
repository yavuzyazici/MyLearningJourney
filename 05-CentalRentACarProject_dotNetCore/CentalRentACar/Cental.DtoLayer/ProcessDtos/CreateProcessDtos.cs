using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DtoLayer.ProcessDtos
{
    public class CreateProcessDtos
    {
        [Key]
        public int ProcessId { get; set; }

        [Required(ErrorMessage = "The Title field is required.")]
        [StringLength(100, ErrorMessage = "The Title must be at most 100 characters long.")]
        public required string Title { get; set; }

        [Required(ErrorMessage = "The Description field is required.")]
        [StringLength(300, ErrorMessage = "The Description must be at most 300 characters long.")]
        public required string Description { get; set; }
    }
}
