using MediatR;
using Todo.Domain.Contracts;

namespace Todo.Application.Commands.Todo
{
    public class SearchTodoByTitleCommand : IRequest<ApiResponse>
    {

        public string searchTerm { get; set; }
    }
}
