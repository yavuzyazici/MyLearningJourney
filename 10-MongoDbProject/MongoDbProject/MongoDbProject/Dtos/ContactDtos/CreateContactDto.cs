using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoDbProject.Dtos.ContactDtos
{
    public class CreateContactDto
    {
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public string EMail { get; set; }
    }
}
