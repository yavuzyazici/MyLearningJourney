using AutoMapper;
using BookStore.BusinessLayer.Abstract;
using BookStore.WebUI.Dtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebUI.ViewComponents.Default
{
    public class _DefaultBannerComponent : ViewComponent
    {
        private readonly IProductService productService;
        private readonly IMapper mapper;

        public _DefaultBannerComponent(IProductService productService, IMapper mapper)
        {
            this.productService = productService;
            this.mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var values = productService.TGetAll().Take(2).ToList();
            var banners = mapper.Map<List<ResultProductDto>>(values);
            return View(banners);
        }
    }
}
