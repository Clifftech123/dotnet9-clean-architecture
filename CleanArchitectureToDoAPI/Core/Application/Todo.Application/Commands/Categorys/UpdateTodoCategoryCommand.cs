using MediatR;
using Todo.Domain.Contracts;

namespace Todo.Application.Commands.Categorys
{
    public class UpdateTodoCategoryCommand : IRequest<ApiResponse>
    {
        public int Id { get; set; }
        public UpdateTodoCategoryRequest? UpdateTodoCategoryRequest { get; set; }
    }
}
