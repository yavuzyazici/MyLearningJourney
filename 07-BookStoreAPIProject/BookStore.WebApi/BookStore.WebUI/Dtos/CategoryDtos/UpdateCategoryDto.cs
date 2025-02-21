namespace BookStore.WebUI.Dtos.CategoryDtos
{
    public class UpdateCategoryDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public IFormFile? ImageFile { get; set; }
    }
}
