using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.EntityLayer.Entities
{
    public class Brand
    {
        [Key]
        public int BrandId { get; set; }

        [Required(ErrorMessage = "The Brand Name is required.")]
        [StringLength(100, ErrorMessage = "The Brand Name must be at most 100 characters long.")]
        public required string BrandName { get; set; }
        public List<Car>? Cars { get; set; }
    }
}
