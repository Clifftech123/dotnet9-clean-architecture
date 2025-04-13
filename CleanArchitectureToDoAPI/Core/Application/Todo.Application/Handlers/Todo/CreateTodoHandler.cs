using AutoMapper;
using MediatR;
using Todo.Application.Commands.Todo;
using Todo.Domain.Contracts;
using Todo.Domain.Entities;
using Todo.Infrastructure.Interface;

namespace Todo.Application.Handlers.Todo
{
    public class CreateTodoHandler : IRequestHandler<CreateTodoCommand, ApiResponse>
    {
        private readonly IBaseRepository<TodoItem> baseRepository;
        private readonly IMapper _mapper;

        public CreateTodoHandler(IBaseRepository<TodoItem> baseRepository, IMapper mapper)
        {
            this.baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
        {
            var todoItem = _mapper.Map<TodoItem>(request.CreateTodoRequest);
            todoItem.CreateDate = DateTime.Now;
            todoItem.UpdateDate = DateTime.Now;
            await baseRepository.AddAsync(todoItem);

            var todoResponseData = _mapper.Map<TodoItemDto>(todoItem);
            var response = new ApiResponse
            {
                Success = true,
                Data = todoResponseData,

                Message = "Todo created successfully"
            };

            return response;

        }
    }
}
