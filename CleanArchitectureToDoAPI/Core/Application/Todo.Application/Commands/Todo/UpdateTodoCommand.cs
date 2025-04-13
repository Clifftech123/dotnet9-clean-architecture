using MediatR;
using Todo.Domain.Contracts;

namespace Todo.Application.Commands.Todo
{
    public class UpdateTodoCommand : IRequest<ApiResponse>
    {
        public int TodoId { get; set; }
        public UpdateTodoRequest? UpdateTodoRequest { get; set; }

    }
}
