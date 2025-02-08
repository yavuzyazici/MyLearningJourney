using Cental.EntityLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DtoLayer.BookingDtos
{
    public class ApproveBookingDto
    {
        [Key]
        public int BookingId { get; set; }
        public BookingStatus BookingStatus { get; set; }
    }
}
