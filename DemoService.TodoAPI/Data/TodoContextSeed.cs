using DemoService.TodoAPI.Entities;
using MongoDB.Driver;

namespace DemoService.TodoAPI.Data
{
    public class TodoContextSeed
    {

        public static void SeedData(IMongoCollection<Todo> TodoCollection)
        {
            bool existTodo = TodoCollection.Find(p => true).Any();
            if (!existTodo)
            {
                TodoCollection.InsertManyAsync(GetMyTodos());
            }
        }

        private static IEnumerable<Todo> GetMyTodos()
        {
            return new List<Todo>()
            {
                new Todo(){
                    Id = "",
                    Title ="Title 10",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
                    "Nulla cursus, purus vehicula mattis euismod, purus tellus auctor arcu, at luctus velit sem eget enim. "
                }
            };
        }
    }
}
