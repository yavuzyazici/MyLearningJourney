using BookStore.BusinessLayer.Concrete;
using BookStore.BusinessLayer.Abstract;
using BookStore.WebUI.Dtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using AutoMapper;
using BookStore.EntityLayer.Concrete;

namespace BookStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IImageService _imageService;
        private readonly IMapper _mapper;

        public ProductController(IHttpClientFactory httpClientFactory, IImageService imageService, IMapper mapper)
        {
            _httpClientFactory = httpClientFactory;
            _imageService = imageService;
            _mapper = mapper;
        }

        public async Task<IActionResult> ProductList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage  = await client.GetAsync("https://localhost:7190/api/Products");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            var client = _httpClientFactory.CreateClient();
            if (createProductDto.ImageFile != null)
            {
                try
                {
                    createProductDto.ImageUrl = await _imageService.SaveImageAsync(createProductDto.ImageFile);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return View(createProductDto);
                }
            }
            var jsonData = JsonConvert.SerializeObject(createProductDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7190/api/Products", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductList");
            }
            return View();
        }

        public async Task<IActionResult> DeleteProduct(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync($"https://localhost:7190/api/Products?id={id}");
            return RedirectToAction("ProductList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7190/api/Products/GetProduct?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetByIdProductDto>(jsonData);
                var product = _mapper.Map<UpdateProductDto>(values);
                return View(product);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            var client = _httpClientFactory.CreateClient();
            if (updateProductDto.ImageFile != null)
            {
                try
                {
                    updateProductDto.ImageUrl = await _imageService.SaveImageAsync(updateProductDto.ImageFile);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return View(updateProductDto);
                }
            }
            var product = _mapper.Map<Product>(updateProductDto);
            var jsonData = JsonConvert.SerializeObject(product);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7190/api/Products/", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductList");
            }
            return View();
        }
    }
}
