using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.EntityLayer.Entities
{
    public class Banner : BaseEntity
    {
        [Key]
        public int BannerId { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string ImageUrl { get; set; }
    }
}
