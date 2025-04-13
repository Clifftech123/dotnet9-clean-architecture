using MediatR;
using Todo.Domain.Contracts;

namespace Todo.Application.Commands.Categorys
{
    public class CreateTodoCategoryCommand : IRequest<ApiResponse>
    {
        public CreateTodoCategoryRequest? CreateTodoCategoryRequest { get; set; }
    }
}
