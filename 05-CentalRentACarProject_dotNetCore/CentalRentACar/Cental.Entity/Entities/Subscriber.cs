using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.EntityLayer.Entities
{
    public class Subscriber : BaseEntity
    {
        public int SubscriberId { get; set; }
        public string Email { get; set; }
    }
}
