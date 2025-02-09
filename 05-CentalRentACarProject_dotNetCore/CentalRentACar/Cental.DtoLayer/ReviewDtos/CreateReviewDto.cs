﻿using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DtoLayer.ReviewDtos
{
    public class CreateReviewDto
    {
        public int BookingId { get; set; }
        public required int Rating { get; set; }
        public required int CarId { get; set; }
    }
}
