﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.EntityLayer.Entities
{
    public class Service
    {
        [Key]
        public int ServiceId { get; set; }

        [Required(ErrorMessage = "The Title field is required.")]
        [StringLength(200, ErrorMessage = "The Title must be at most 200 characters long.")]
        public required string Title { get; set; }

        [Required(ErrorMessage = "The Description field is required.")]
        [StringLength(300, ErrorMessage = "The Description must be at most 300 characters long.")]
        public required string Description { get; set; }

        [Required(ErrorMessage = "The Icon field is required.")]
        public required string Icon { get; set; }
    }
}
