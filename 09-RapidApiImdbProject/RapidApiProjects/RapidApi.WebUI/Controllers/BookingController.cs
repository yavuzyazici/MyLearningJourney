using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RapidApi.WebUI.Models;
using System.Net.Http.Headers;

namespace RapidApi.WebUI.Controllers
{
    public class BookingController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(HotelRequestModel hotelRequestModel)
        {
            var client = new HttpClient();
            var requestDestination = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com15.p.rapidapi.com/api/v1/hotels/searchDestination?query={hotelRequestModel.Address}"),
                Headers =
        {
            { "x-rapidapi-key", "757b9ebcb9msh2af26e146e66113p1b5132jsnfd7def321b97" },
            { "x-rapidapi-host", "booking-com15.p.rapidapi.com" },
        },
            };

            using (var response = await client.SendAsync(requestDestination))
            {
                response.EnsureSuccessStatusCode();
                var jsonBody = await response.Content.ReadAsStringAsync();
                var root = JsonConvert.DeserializeObject<HotelDestinationResponseModel.Rootobject>(jsonBody);
                if (root?.data != null && root.data.Count() > 0)
                {
                    hotelRequestModel.destId = root.data.First().dest_id;
                }
                else
                {
                    throw new Exception("Destination data not found!");
                }
            }

            var requestHotels = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com15.p.rapidapi.com/api/v1/hotels/searchHotels?dest_id={hotelRequestModel.destId}&search_type=CITY&arrival_date={hotelRequestModel.ArrivalDate.ToString("yyyy-MM-dd")}&departure_date={hotelRequestModel.DepartureDate.ToString("yyyy-MM-dd")}&adults={hotelRequestModel.AdultCount}&page_number=1&units=metric&temperature_unit=c&languagecode=en-us&currency_code={hotelRequestModel.CurrencyCode}"),
                Headers =
        {
            { "x-rapidapi-key", "757b9ebcb9msh2af26e146e66113p1b5132jsnfd7def321b97" },
            { "x-rapidapi-host", "booking-com15.p.rapidapi.com" },
        },
            };

            using (var response = await client.SendAsync(requestHotels))
            {
                response.EnsureSuccessStatusCode();
                var jsonBody = await response.Content.ReadAsStringAsync();
                var root = JsonConvert.DeserializeObject<HotelsResponseViewModel.Rootobject>(jsonBody);
                return View(root);
            }
        }
    }
}
