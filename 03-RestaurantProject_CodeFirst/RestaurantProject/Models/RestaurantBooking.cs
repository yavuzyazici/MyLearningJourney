using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace RestaurantProject.Models
{
    public class RestaurantBooking
    {
        [Key]
        [Required(ErrorMessage = "Booking ID is required.")]
        public int RestaurantBookingId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        [StringLength(200, ErrorMessage = "Email cannot exceed 200 characters.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone is required.")]
        [StringLength(15, MinimumLength = 10, ErrorMessage = "Phone must be between 10 and 15 characters.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Booking date is required.")]
        public DateTime BookingDate { get; set; }

        [Required(ErrorMessage = "Booking hour is required.")]
        public TimeSpan BookingHour { get; set; }

        [Required(ErrorMessage = "Person count is required.")]
        [Range(1, 100, ErrorMessage = "Person count must be between 1 and 100.")]
        public int PersonCount { get; set; }

        [StringLength(1000, ErrorMessage = "Message content cannot exceed 1000 characters.")]
        public string MessageContent { get; set; }

        [Required(ErrorMessage = "Approval status is required.")]
        public bool IsApproved { get; set; }
    }
}