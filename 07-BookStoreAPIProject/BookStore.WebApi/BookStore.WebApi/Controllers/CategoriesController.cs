using BookStore.BusinessLayer.Abstract;
using BookStore.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public IActionResult CategoryList()
        {
            var values = _categoryService.TGetAll();
            return Ok(values);
        }

        [HttpGet("GetCategoriesWithProducts")]
        public IActionResult GetCategoriesWithProducts()
        {
            var values = _categoryService.TGetCategoriesWithProducts().Where(x=> x.Products != null);
            return Ok(values);
        }
        [HttpGet("GetCategory")]
        public IActionResult GetCategory(int id)
        {
            return Ok(_categoryService.TGetById(id));
        }

        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            _categoryService.TAdd(category);
            return Ok("Category added succesfully");
        }

        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            _categoryService.TDelete(id);
            return Ok("Category deleted succesfully");
        }
        [HttpPut]
        public IActionResult UpdateCategory(Category category)
        {
            _categoryService.TUpdate(category);
            return Ok("Category updated succesfully");
        }
    }
}
