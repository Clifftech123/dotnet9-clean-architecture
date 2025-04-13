using AutoMapper;
using MediatR;
using Todo.Application.Exceptions;
using Todo.Application.Queries.Todo;
using Todo.Domain.Contracts;
using Todo.Domain.Entities;
using Todo.Infrastructure.Interface;

namespace Todo.Application.Handlers.Todo
{
    public class GetTodoByIdQueryHandler : IRequestHandler<GetTodoByIdQuery, ApiResponse>
    {
        private readonly IBaseRepository<TodoItem> baseRepository;
        private readonly IMapper _mapper;

        public GetTodoByIdQueryHandler(IBaseRepository<TodoItem> baseRepository, IMapper mapper)
        {
            this.baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse> Handle(GetTodoByIdQuery request, CancellationToken cancellationToken)
        {
            var todo = await baseRepository.GetByIdAsync(request.TodoId);
            if (todo == null)
            {
                throw new TodoNotFoundException(request.TodoId);
            }
            var getTodoById = _mapper.Map<TodoItemDto>(todo);
            var response = new ApiResponse
            {
                Success = true,
                Data = getTodoById,
                Message = "Todo fetched successfully"
            };
            return response;
        }
    }
}
