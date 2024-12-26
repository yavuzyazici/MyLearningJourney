﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.EntityLayer.Entities
{
    public class Review
    {
        public int ReviewId { get; set; }
        public required int Rating { get; set; }
        public required int CarId { get; set; }
        public required Car Car { get; set; }
    }
}
