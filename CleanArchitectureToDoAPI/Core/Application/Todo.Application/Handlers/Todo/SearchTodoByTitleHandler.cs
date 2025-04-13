using AutoMapper;
using MediatR;
using Todo.Application.Commands.Todo;
using Todo.Domain.Contracts;
using Todo.Domain.Entities;
using Todo.Infrastructure.Interface;

namespace Todo.Application.Handlers.Todo
{
    public class SearchTodoByTitleHandler : IRequestHandler<SearchTodoByTitleCommand, ApiResponse>
    {
        private readonly IBaseRepository<TodoItem> baseRepository;
        private readonly IMapper _mapper;

        public SearchTodoByTitleHandler(IBaseRepository<TodoItem> baseRepository, IMapper mapper)
        {
            this.baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse> Handle(SearchTodoByTitleCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.searchTerm))
            {
                return new ApiResponse
                {
                    Success = false,
                    Message = "Search term is required",
                    Data = new List<TodoItemDto>()
                };
            }

            var todos = await baseRepository.SearchTodoAsync(request.searchTerm);
            if (todos == null || !todos.Any())
            {
                return new ApiResponse
                {
                    Success = false,
                    Message = "No todos found",
                    Data = new List<TodoItemDto>()
                };
            }
            var result = _mapper.Map<List<TodoItemDto>>(todos);
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

