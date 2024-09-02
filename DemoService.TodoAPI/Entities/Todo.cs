using MongoDB.Bson.Serialization.Attributes;

namespace DemoService.TodoAPI.Entities
{
    public class Todo : Entity
    {
        [BsonElement("Name")]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
