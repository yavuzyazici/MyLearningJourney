using BookStore.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController : ControllerBase
    {
        private readonly IProductService _productService;
        public BannersController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult BannerList()
        {
            var values = _productService.TGetAll().Take(2).ToList();
            return Ok(values);
        }
    }
}
