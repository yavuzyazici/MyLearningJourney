namespace BookStore.WebUI.Dtos.CategoryDtos
{
    public class CreateCategoryDto
    {
        public string CategoryName { get; set; }
        public IFormFile? ImageFile { get; set; }
    }
}
