﻿using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DtoLayer.BrandDtos
{
    public class ResultBrandDto
    {
        [Key]
        public int BrandId { get; set; }
        public required string BrandName { get; set; }
    }
}
