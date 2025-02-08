using Cental.EntityLayer.Entities;
using Cental.EntityLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Cental.DtoLayer.BookingDtos
{
    public class UIBookingDto
    {
        public string PickUpPlace { get; set; }
        public DateTime PickUpDate { get; set; }
        public TimeOnly PickUpTime { get; set; }
        public string DropOffPlace { get; set; }
        public DateTime DropOffDate { get; set; }
        public TimeOnly DropOffTime { get; set; }
        public int UserId { get; set; }
        public int CarId { get; set; }
        public BookingStatus BookingStatus { get; set; }
    }
}
