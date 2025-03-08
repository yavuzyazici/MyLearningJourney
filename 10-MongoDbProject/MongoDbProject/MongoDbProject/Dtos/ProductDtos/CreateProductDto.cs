﻿namespace MongoDbProject.Dtos.ProductDtos
{
    public class CreateProductDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }

        public string InstructorName { get; set; }
    }
}
