using DemoService.TodoAPI.Entities;

namespace DemoService.TodoAPI.Repositories
{
    public interface ITodoRepository
    {
        Task<IEnumerable<Todo>> GetTodos();
        Task<Todo> GetTodo(string id);
        Task<IEnumerable<Todo>> GetTodoByTitle(string title);
        Task CreateTodo(Todo todo);
        Task<bool> UpdateTodo(Todo todo);
        Task<bool> DeleteTodo(string id);
    }
}
