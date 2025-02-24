using Newtonsoft.Json;

namespace BookStore.WebUI.Dtos.ProductDtos
{
    public class UpdateProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductStock { get; set; }
        public decimal ProductPrice { get; set; }
        [JsonIgnore]
        public IFormFile? ImageFile { get; set; }
        public string ProductDescription { get; set; }
        public string ProductAuthor { get; set; }
        public string? ImageUrl { get; set; }
        public int CategoryId { get; set; }
    }
}
