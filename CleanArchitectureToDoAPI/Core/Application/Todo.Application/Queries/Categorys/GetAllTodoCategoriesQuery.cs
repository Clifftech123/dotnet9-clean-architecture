using MediatR;
using Todo.Domain.Contracts;

namespace Todo.Application.Queries.Categorys
{
    public class GetAllTodoCategoriesQuery : IRequest<ApiResponse>
    {
    }
}
