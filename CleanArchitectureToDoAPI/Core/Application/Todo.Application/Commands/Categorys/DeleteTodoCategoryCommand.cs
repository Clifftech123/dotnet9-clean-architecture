using MediatR;
using Todo.Domain.Contracts;

namespace Todo.Application.Commands.Categorys
{
    public class DeleteTodoCategoryCommand : IRequest<ApiResponse>
    {
        public int CategoryId { get; set; }
    }
}
