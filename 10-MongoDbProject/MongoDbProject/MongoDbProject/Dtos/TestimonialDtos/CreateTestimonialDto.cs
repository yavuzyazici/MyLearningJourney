﻿namespace MongoDbProject.Dtos.TestimonialDtos
{
    public class CreateTestimonialDto
    {
        public string ClientName { get; set; }
        public string JobTitle { get; set; }
        public string? ImageUrl { get; set; }
        public IFormFile? ImageFile { get; set; }
        public string Rating { get; set; }
        public string Review { get; set; }
    }
}
