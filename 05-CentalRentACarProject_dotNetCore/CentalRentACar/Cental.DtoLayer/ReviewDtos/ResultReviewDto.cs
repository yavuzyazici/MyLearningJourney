using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DtoLayer.ReviewDtos
{
    public class ResultReviewDto
    {
        public int BookingId { get; set; }
        public bool IsReviewed { get; set; }
        public required int CarId { get; set; }
        public virtual Car Car { get; set; }

    }
}
