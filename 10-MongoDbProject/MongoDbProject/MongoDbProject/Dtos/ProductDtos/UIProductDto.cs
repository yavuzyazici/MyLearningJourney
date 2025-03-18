﻿namespace MongoDbProject.Dtos.ProductDtos
{
    public class UIProductDto
    {
        public string ProductId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }

        public string InstructorName { get; set; }
        public string InstructorImageUrl { get; set; }
        public string InstructorTitle { get; set; }
    }
}
