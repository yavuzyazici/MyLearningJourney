using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace RestaurantProject.Models
{
    public class RestaurantMessage
    {
        [Key]
        [Required(ErrorMessage = "Message ID is required.")]
        public int RestaurantMessageId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        [StringLength(200, ErrorMessage = "Email cannot exceed 200 characters.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Subject is required.")]
        [StringLength(150, MinimumLength = 5, ErrorMessage = "Subject must be between 5 and 150 characters.")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Message content is required.")]
        [StringLength(1000, MinimumLength = 10, ErrorMessage = "Message content must be between 10 and 1000 characters.")]
        public string MessageContent { get; set; }

        [Required(ErrorMessage = "IsRead status is required.")]
        public bool IsRead { get; set; }
    }
}