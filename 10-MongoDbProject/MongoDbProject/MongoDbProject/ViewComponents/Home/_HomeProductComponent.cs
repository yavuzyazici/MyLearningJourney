using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDbProject.DataAccess.Entities;
using MongoDbProject.Dtos.ProductDtos;
using MongoDbProject.Services.InstructorServices;
using MongoDbProject.Services.ProductServices;

namespace MongoDbProject.ViewComponents.Home
{
    public class _HomeProductComponent(IProductService _productService, IInstructorService _instructorService, IMapper _mapper) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _productService.GetAllAsync();
            var product = _mapper.Map<List<UIProductDto>>(value.Take(3));

            var instructorList = await _instructorService.GetAllAsync();

            foreach (var productDto in product)
            {
                var instructor = instructorList.FirstOrDefault(i => i.FullName == productDto.InstructorName);
                if (instructor != null)
                {
                    productDto.InstructorImageUrl = instructor.ImageUrl ?? "/images/no-pic.png";
                    productDto.InstructorTitle = instructor.Title;
                }
            }

            return View(product);
        }
    }
}
