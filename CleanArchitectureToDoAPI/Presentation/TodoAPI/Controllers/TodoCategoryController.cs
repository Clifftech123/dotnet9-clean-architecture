using Microsoft.AspNetCore.Mvc;
using Todo.Application.Commands.Categorys;
using Todo.Application.Queries.Categorys;
using Todo.Domain.Contracts;

namespace TodoAPI.Controllers
{
    public class TodoCategoryController : BaseApiController
    {

        [HttpGet("categories/all")]

        public async Task<IActionResult> GetAllTodoCategories()
        {
            var response = await mediator.Send(new GetAllTodoCategoriesQuery());
            return Ok(response);
        }



        [HttpPost("categories")]
        public async Task<IActionResult> CreateTodoCategory([FromBody] CreateTodoCategoryRequest createTodoCategoryRequest)
        {
            var response = await mediator.Send(new CreateTodoCategoryCommand { CreateTodoCategoryRequest = createTodoCategoryRequest });
            return Ok(response);

        }

        [HttpGet("categories/{categoryId:int}")]

        public async Task<IActionResult> GetTodoCategoryById(int categoryId)
        {
            var response = await mediator.Send(new GetTodoCategoryByIdQuery { CategoryId = categoryId });
            return Ok(response);
        }

        [HttpPut("categories/{id:int}")]
        public async Task<IActionResult> UpdateTodoCategory(int id, [FromBody] UpdateTodoCategoryRequest updateTodoCategoryRequest)
        {
            var response = await mediator.Send(new UpdateTodoCategoryCommand { Id = id, UpdateTodoCategoryRequest = updateTodoCategoryRequest });
            return Ok(response);
        }


        [HttpDelete("categories/{categoryId:int}")]

        public async Task<IActionResult> DeleteTodoCategory(int categoryId)
        {
            var response = await mediator.Send(new DeleteTodoCategoryCommand { CategoryId = categoryId });
            return Ok(response);
        }









    }
}
