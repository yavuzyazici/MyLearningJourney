using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.EntityLayer.Entities
{
    public class About : BaseEntity
    {
        [Key]
        public int AboutId { get; set; }
        public required string Mission { get; set; }
        public required string Vision { get; set; }
        public required string Description1 { get; set; }
        public required string Description2 { get; set; }
        public int StartYear { get; set; }
        public required string ImageUrlBig { get; set; }
        public required string ImageUrlSmall { get; set; }
        public required string Item1 { get; set; }
        public required string Item2 { get; set; }
        public required string Item3 { get; set; }
        public required string Item4 { get; set; }
        public required string NameSurname { get; set; }
        public required string JobTitle { get; set; }
        public required string ProfilePictureUrl { get; set; }
    }
}
