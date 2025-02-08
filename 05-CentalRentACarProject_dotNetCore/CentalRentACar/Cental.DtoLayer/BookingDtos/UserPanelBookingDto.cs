using Cental.EntityLayer.Entities;
using Cental.EntityLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DtoLayer.BookingDtos
{
    public class UserPanelBookingDto
    {
        public int BookingID { get; set; }
        public string PickUpPlace { get; set; }
        public DateTime PickUpDate { get; set; }
        public string DropOffPlace { get; set; }
        public DateTime DropOffDate { get; set; }
        public int UserId { get; set; }
        public virtual Car Car { get; set; }
        public BookingStatus BookingStatus { get; set; }
    }
}
