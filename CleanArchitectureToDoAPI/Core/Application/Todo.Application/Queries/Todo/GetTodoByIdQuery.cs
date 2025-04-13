using MediatR;
using Todo.Domain.Contracts;

namespace Todo.Application.Queries.Todo
{

    public class GetTodoByIdQuery : IRequest<ApiResponse>
    {
        public int TodoId { get; set; }

    }

}
