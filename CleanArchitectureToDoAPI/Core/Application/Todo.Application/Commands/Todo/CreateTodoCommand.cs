using MediatR;
using Todo.Domain.Contracts;

namespace Todo.Application.Commands.Todo
{
    public class CreateTodoCommand : IRequest<ApiResponse>
    {
        public CreateTodoRequest? CreateTodoRequest { get; set; }
    }
}
