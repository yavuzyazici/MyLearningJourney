using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DtoLayer.ContactDtos
{
    public class UpdateContactDto
    {
        public int ContactId { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string EMail { get; set; }
        public string Phone { get; set; }
        public string MapUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string XUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string LinkedinUrl { get; set; }
    }
}
