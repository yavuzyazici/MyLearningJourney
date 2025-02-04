using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.EntityLayer.Entities
{
    public class Process : BaseEntity
    {
        [Key]
        public int ProcessId { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
    }
}
