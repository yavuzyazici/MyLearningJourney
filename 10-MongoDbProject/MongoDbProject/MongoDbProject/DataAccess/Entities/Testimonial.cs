using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoDbProject.DataAccess.Entities
{
    public class Testimonial
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string TestimonialId { get; set; }
        public string ClientName { get; set; }
        public string ImageUrl { get; set; }
        public string JobTitle { get; set; }
        public string Rating { get; set; }
        public string Review { get; set; }
    }
}
