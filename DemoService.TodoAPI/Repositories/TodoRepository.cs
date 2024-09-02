using DemoService.TodoAPI.Data;
using DemoService.TodoAPI.Entities;
using MongoDB.Driver;

namespace DemoService.TodoAPI.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly ITodoContext _context;
        public TodoRepository(ITodoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task CreateTodo(Todo todo)
        {
            await _context.Todoes.InsertOneAsync(todo);
        }

        public async Task<bool> DeleteTodo(string id)
        {
            FilterDefinition<Todo> filter = Builders<Todo>.Filter.Eq(p => p.Id, id);
            DeleteResult deleteResult = await _context.Todoes.DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        
        public async Task<Todo> GetTodo(string id)
        {
            return await _context.Todoes.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Todo>> GetTodoByTitle(string name)
        {
            FilterDefinition<Todo> filter = Builders<Todo>.Filter.ElemMatch(p => p.Title, name);
            return await _context.Todoes.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Todo>> GetTodos()
        {
            return await _context.Todoes.Find(p => true).ToListAsync();
        }

        public async Task<bool> UpdateTodo(Todo todo)
        {
            var updateResult = await _context.Todoes.ReplaceOneAsync(
                filter: g => g.Id == todo.Id, replacement: todo);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
