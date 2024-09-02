using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DemoService.TodoAPI.Entities
{
    public class Entity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

    }
}