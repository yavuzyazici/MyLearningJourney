using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.EntityLayer.Entities
{
    public class Branch : BaseEntity
    {
        public int BranchId { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
    }
}
