using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RestaurantProject.Models
{
    public class RestaurantMeta
    {
        public int RestaurantMetaId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        [NotMapped]
        public HttpPostedFileBase ogImage { get; set; }
    }
}