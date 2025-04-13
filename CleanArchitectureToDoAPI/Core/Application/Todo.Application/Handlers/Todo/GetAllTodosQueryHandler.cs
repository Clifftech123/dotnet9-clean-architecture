using AutoMapper;
using MediatR;
using Todo.Application.Queries.Todo;
using Todo.Domain.Contracts;
using Todo.Domain.Entities;
using Todo.Infrastructure.Interface;

namespace Todo.Application.Handlers.Todo
{
    public class GetAllTodosQueryHandler : IRequestHandler<GetAllTodosQuery, ApiResponse>
    {
        private readonly IBaseRepository<TodoItem> baseRepository;
        private readonly IMapper _mapper;

        public GetAllTodosQueryHandler(IBaseRepository<TodoItem> baseRepository, IMapper mapper)
        {
            this.baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse> Handle(GetAllTodosQuery request, CancellationToken cancellationToken)
        {
            var getAllTodos = await baseRepository.GetAllAsync();

            if (getAllTodos == null || !getAllTodos.Any())
            {
                return new ApiResponse
                {
                    Success = false,
                    Message = "No Todo found",
                    Data = new List<TodoItem>()
                };
            }

            var result = _mapper.Map<List<TodoItemDto>>(getAllTodos);
            var response = new ApiResponse
            {
                Success = true,
                Data = result,
                Message = "Todo fetched successfully"
            };
            return response;



        }
    }
}
