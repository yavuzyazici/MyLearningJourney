using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DtoLayer.TestimonialDtos
{
    public class UITestimonialDto
    {
        public required string ImageUrl { get; set; }
        public required string NameSurname { get; set; }
        public required string JobTitle { get; set; }
        public int Review { get; set; }
        public required string Comment { get; set; }
        public bool IsAproved { get; set; }
    }
}
