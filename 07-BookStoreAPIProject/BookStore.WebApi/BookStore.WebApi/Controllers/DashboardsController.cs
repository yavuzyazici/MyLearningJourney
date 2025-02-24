using BookStore.BusinessLayer.Abstract;
using BookStore.EntityLayer.Concrete;
using BookStore.WebUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace BookStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardsController : ControllerBase
    {
        private readonly IDashboardService _dashboardService;

        public DashboardsController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [HttpGet]
        public IActionResult Dashboard()
        {
            var model = new DashboardViewModel
            {
                ProductCount = _dashboardService.GetCount<Product>(),
                AverageProductPrice = $"${_dashboardService.GetList<Product>().Average(x => x.ProductPrice):0.00}",
                AverageProductStock = (int)_dashboardService.GetList<Product>().Average(x=> x.ProductStock),
                LowestProductStock = _dashboardService.GetList<Product>().OrderBy(x => x.ProductStock).FirstOrDefault().ProductStock,
                HighestProductStock = _dashboardService.GetList<Product>().OrderByDescending(x => x.ProductStock).FirstOrDefault().ProductStock,
                NovelProductsStock = _dashboardService.Where<Product>(x => x.CategoryId == 1).Sum(x => x.ProductStock),
                SubscriberCount = _dashboardService.GetCount<Subscriber>(),
                LatestSubscriberEmail = _dashboardService.GetList<Subscriber>().OrderByDescending(x => x.SubscriberId).First().Email,
                CategoryCount = _dashboardService.GetCount<Category>(),
                QuoteCount = _dashboardService.GetCount<Quote>(),
                MostExpensiveProduct = _dashboardService.GetList<Product>().OrderByDescending(x => x.ProductPrice).First().ProductName,
                NovelProductCount = _dashboardService.Where<Product>(x=> x.CategoryId == 1).Count,
                NovelStock = _dashboardService.Where<Product>(x => x.CategoryId == 1).Sum(x=> x.ProductStock),
                PoetryProductCount = _dashboardService.Where<Product>(x => x.CategoryId == 3).Count,
                PoetryStock = _dashboardService.Where<Product>(x => x.CategoryId == 3).Sum(x => x.ProductStock),
                StoryProductCount = _dashboardService.Where<Product>(x => x.CategoryId == 2).Count,
                StoryStock = _dashboardService.Where<Product>(x => x.CategoryId == 2).Sum(x => x.ProductStock),
                AcademicBookProductCount = _dashboardService.Where<Product>(x => x.CategoryId == 4).Count,
                AcademicBookStock = _dashboardService.Where<Product>(x => x.CategoryId == 4).Sum(x => x.ProductStock),
                TextbookProductCount = _dashboardService.Where<Product>(x => x.CategoryId == 5).Count,
                TextbookStock = _dashboardService.Where<Product>(x => x.CategoryId == 5).Sum(x => x.ProductStock),
                LatestProducts = _dashboardService.GetList<Product>().OrderByDescending(x => x.ProductId).Take(5).ToList(),
                CategoryList = _dashboardService.GetList<Category>()
            };
            return Ok(model);
        }
    }
}
