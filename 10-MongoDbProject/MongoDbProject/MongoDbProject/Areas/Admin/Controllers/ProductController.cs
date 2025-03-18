using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MongoDbProject.Dtos.InstructorDtos;
using MongoDbProject.Dtos.ProductDtos;
using MongoDbProject.Services.ImageServices;
using MongoDbProject.Services.InstructorServices;
using MongoDbProject.Services.ProductServices;

namespace MongoDbProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController(IProductService _productService, IInstructorService _instructorService, IImageService _imageService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await _productService.GetAllAsync();
            return View(values);
        }

        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> CreateProduct()
        {
            var instructors = await _instructorService.GetAllAsync();
            ViewBag.Instructors = (from x in instructors
                                   select new SelectListItem
                                   {
                                       Text = x.FullName,
                                       Value = x.FullName
                                   }).ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
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

            await _productService.CreateAsync(createProductDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateProduct(string id)
        {
            var instructors = await _instructorService.GetAllAsync();
            ViewBag.Instructors = (from x in instructors
                                   select new SelectListItem
                                   {
                                       Text = x.FullName,
                                       Value = x.FullName
                                   }).ToList();

            var value = await _productService.GetByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
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

            await _productService.UpdateAsync(updateProductDto);
            return RedirectToAction("Index");
        }
    }
}
