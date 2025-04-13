using Microsoft.AspNetCore.Mvc;
using Todo.Application.Commands.Todo;
using Todo.Application.Queries.Todo;
using Todo.Domain.Contracts;

namespace TodoAPI.Controllers
{
    public class TodoController : BaseApiController
    {
        [HttpGet("todo/all")]
        public async Task<IActionResult> GetAllTodos()
        {
            return Ok(await mediator.Send(new GetAllTodosQuery()));
        }


        [HttpGet("todo/{id}")]
        public async Task<IActionResult> GetTodoById(int id)
        {
            return Ok(await mediator.Send(new GetTodoByIdQuery { TodoId = id }));
        }

        [HttpPost("todo")]

        public async Task<IActionResult> CreateTodo([FromBody] CreateTodoRequest createTodoRequest)
        {
            var response = await mediator.Send(new CreateTodoCommand { CreateTodoRequest = createTodoRequest });
            return Ok(response);

        }


        [HttpPut("todo/{id}")]

        public async Task<IActionResult> UpdateTodo(int id, [FromBody] UpdateTodoRequest updateTodoRequest)
        {
            var response = await mediator.Send(new UpdateTodoCommand { TodoId = id, UpdateTodoRequest = updateTodoRequest });
            return Ok(response);
        }


        [HttpDelete("todo/{id}")]
        public async Task<IActionResult> DeleteTodo(int todoId)
        {
            var response = await mediator.Send(new DeleteTodoCommand { TodoId = todoId });
            return Ok(response);
        }


        [HttpGet("todo/search")]
        public async Task<IActionResult> SearchTodos([FromQuery] string searchTerm)
        {
            var response = await mediator.Send(new SearchTodoByTitleCommand { searchTerm = searchTerm });

            return Ok(response);
        }

    }
}
