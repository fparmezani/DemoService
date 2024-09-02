using DemoService.TodoAPI.Entities;
using MongoDB.Driver;

namespace DemoService.TodoAPI.Data
{
    public class TodoContext : ITodoContext
    {

        public TodoContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:Databasename"));

            Todoes = database.GetCollection<Todo>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));

            TodoContextSeed.SeedData(Todoes);
        }


        public IMongoCollection<Todo> Todoes { get; }

        
    }
}
