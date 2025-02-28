using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApi.WebUI.Models;
using System.Net.Http.Headers;

namespace RapidApi.WebUI.Controllers
{
    public class GasController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://gas-price.p.rapidapi.com/europeanCountries"),
                Headers =
    {
        { "x-rapidapi-key", "757b9ebcb9msh2af26e146e66113p1b5132jsnfd7def321b97" },
        { "x-rapidapi-host", "gas-price.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var jsonBody = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GasPriceViewModel>(jsonBody);
                return View(values.Results);
            }
        }
    }
}
