using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace RestaurantProject.Models
{
    public class RestaurantMessage
    {
        public int RestaurantMessageId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string MessageContent { get; set; }
        public bool IsRead { get; set; }
    }
}