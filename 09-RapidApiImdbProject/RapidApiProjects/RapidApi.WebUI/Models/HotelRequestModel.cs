using System.ComponentModel.DataAnnotations;

namespace RapidApi.WebUI.Models
{
    public class HotelRequestModel
    {
        public string? destId { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public int AdultCount { get; set; }
        public string Address { get; set; }
        public string CurrencyCode { get; set; }
    }
}