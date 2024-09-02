using DemoService.TodoAPI.Entities;
using MongoDB.Driver;

namespace DemoService.TodoAPI.Data
{
    public interface ITodoContext
    {
        IMongoCollection<Todo> Todoes { get; }
    }
}
