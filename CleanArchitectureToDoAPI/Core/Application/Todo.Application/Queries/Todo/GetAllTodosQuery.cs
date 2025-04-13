using MediatR;
using Todo.Domain.Contracts;

namespace Todo.Application.Queries.Todo
{
    public class GetAllTodosQuery : IRequest<ApiResponse>
    {
    }
}
