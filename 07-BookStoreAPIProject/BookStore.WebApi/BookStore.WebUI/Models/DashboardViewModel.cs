using BookStore.EntityLayer.Concrete;

namespace BookStore.WebUI.Models
{
    public class DashboardViewModel
    {
        public int ProductCount { get; set; }
        public string AverageProductPrice { get; set; }
        public int AverageProductStock { get; set; }
        public int LowestProductStock { get; set; }
        public int HighestProductStock { get; set; }
        public int NovelProductsStock { get; set; }
        public int SubscriberCount { get; set; }
        public string LatestSubscriberEmail { get; set; }
        public int CategoryCount { get; set; }
        public int QuoteCount { get; set; }
        public string MostExpensiveProduct { get; set; }
        public int NovelStock {  get; set; }
        public int NovelProductCount { get; set; }
        public int PoetryStock { get; set; }
        public int PoetryProductCount { get; set; }
        public int StoryStock { get; set; }
        public int StoryProductCount { get; set; }
        public int AcademicBookStock { get; set; }
        public int AcademicBookProductCount { get; set; }
        public int TextbookStock { get; set; }
        public int TextbookProductCount { get; set; }
        public List<Product> LatestProducts { get; set; }
        public List<Category> CategoryList { get; set; }
    }
}
