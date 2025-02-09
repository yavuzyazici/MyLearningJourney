using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DtoLayer.ContactDtos
{
    public class ResultContactDto
    {
        public int ContactId { get; set; }
        public string EMail { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
