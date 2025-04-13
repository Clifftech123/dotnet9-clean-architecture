using AutoMapper;
using MediatR;
using Todo.Application.Commands.Todo;
using Todo.Application.Exceptions;
using Todo.Domain.Contracts;
using Todo.Domain.Entities;
using Todo.Infrastructure.Interface;

namespace Todo.Application.Handlers.Todo
{
    public class UpdateTodoHandler : IRequestHandler<UpdateTodoCommand, ApiResponse>
    {
        private readonly IBaseRepository<TodoItem> baseRepository;
        private readonly IMapper _mapper;

        public UpdateTodoHandler(IBaseRepository<TodoItem> baseRepository, IMapper mapper)
        {
            this.baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
        {
            var exisitingTodo = await baseRepository.GetByIdAsync(request.TodoId);
            if (exisitingTodo == null)
            {
                throw new TodoNotFoundException(request.TodoId);
            }

            _mapper.Map(request.UpdateTodoRequest, exisitingTodo);
            exisitingTodo.UpdateDate = DateTime.Now;
            var updatedTodo = await baseRepository.UpdateAsync(exisitingTodo);
            var todoResponseData = _mapper.Map<TodoItemDto>(updatedTodo);

            return new ApiResponse
            {
                Success = true,
                Data = todoResponseData,
                Message = "Todo updated successfully"
            };
        }
    }
}
