using DemoService.TodoAPI.Entities;
using DemoService.TodoAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DemoService.TodoAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository _repository;

        public TodoController(ITodoRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }


        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Todo>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Todo>>> GetTodos()
        {

            var Todos = await _repository.GetTodos();
            return Ok(Todos);

        }

        [HttpGet("{id:length(24)}", Name = "GetTodo")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(IEnumerable<Todo>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Todo>>> GetTodoById(string id)
        {

            var Todo = await _repository.GetTodo(id);

            if (Todo is null)
                return null;

            return Ok(Todo);

        }

        [HttpPost]
        [ProducesResponseType(typeof(Todo), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Todo>> CreateTodo([FromBody] Todo Todo)
        {
            if (Todo is null)
                return BadRequest("Invalid Todo");

            await _repository.CreateTodo(Todo);

            return CreatedAtRoute("GetTodo", new { id = Todo.Id }, Todo);

        }

        [HttpPut]
        [ProducesResponseType(typeof(Todo), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateTodo([FromBody] Todo Todo)
        {
            if (Todo is null)
                return BadRequest("Invalid Todo");

            return Ok(await _repository.UpdateTodo(Todo));

        }


        [HttpDelete("{id:length(24)}", Name = "DeleteTodo")]
        [ProducesResponseType(typeof(Todo), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteTodoById(string id)
        {
            return Ok(await _repository.DeleteTodo(id));
        }
    }
}
