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
        public required string BrandName { get; set; }
        public List<Car>? Cars { get; set; }
    }
}
