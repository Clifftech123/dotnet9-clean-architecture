using MediatR;
using Todo.Domain.Contracts;

namespace Todo.Application.Queries.Categorys
{
    public class GetTodoCategoryByIdQuery : IRequest<ApiResponse>
    {
        public int CategoryId { get; set; }
    }
}
