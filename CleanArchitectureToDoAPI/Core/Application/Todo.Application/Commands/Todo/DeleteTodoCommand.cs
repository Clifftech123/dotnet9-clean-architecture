using MediatR;
using Todo.Domain.Contracts;

namespace Todo.Application.Commands.Todo
{
    public class DeleteTodoCommand : IRequest<ApiResponse>
    {
        public int TodoId { get; set; }
    }
}
