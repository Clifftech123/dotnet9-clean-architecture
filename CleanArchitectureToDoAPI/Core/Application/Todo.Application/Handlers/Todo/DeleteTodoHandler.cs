using MediatR;
using Todo.Application.Commands.Todo;
using Todo.Domain.Contracts;
using Todo.Domain.Entities;
using Todo.Infrastructure.Interface;

namespace Todo.Application.Handlers.Todo
{
    public class DeleteTodoHandler : IRequestHandler<DeleteTodoCommand, ApiResponse>
    {
        private readonly IBaseRepository<TodoItem> baseRepository;

        public DeleteTodoHandler(IBaseRepository<TodoItem> baseRepository)
        {
            this.baseRepository = baseRepository;
        }

        public async Task<ApiResponse> Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse();
            var todo = await baseRepository.GetByIdAsync(request.TodoId);
            if (todo == null)
            {
                response.Success = false;
                response.Message = "Todo not found";

            }

            await baseRepository.DeleteAsync(todo);
            response.Success = true;
            response.Message = "Todo deleted successfully";
            return response;


        }
    }
}
