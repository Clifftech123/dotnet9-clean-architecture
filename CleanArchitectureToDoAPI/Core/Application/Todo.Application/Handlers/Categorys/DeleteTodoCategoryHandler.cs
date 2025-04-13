using MediatR;
using Todo.Application.Commands.Categorys;
using Todo.Application.Exceptions;
using Todo.Domain.Contracts;
using Todo.Domain.Entities;
using Todo.Infrastructure.Interface;

namespace Todo.Application.Handlers.Categorys
{
    public class DeleteTodoCategoryHandler : IRequestHandler<DeleteTodoCategoryCommand, ApiResponse>
    {
        private readonly IBaseRepository<TodoCategory> baseRepository;

        public DeleteTodoCategoryHandler(IBaseRepository<TodoCategory> baseRepository)
        {
            this.baseRepository = baseRepository;
        }

        public async Task<ApiResponse> Handle(DeleteTodoCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse();
            var todo = await baseRepository.GetByIdAsync(request.CategoryId);
            if (todo == null)
            {
                throw new CategoryNotFoundException(request.CategoryId);
            }
            await baseRepository.DeleteAsync(todo);
            response.Success = true;
            response.Message = "Todo deleted successfully";
            return response;
        }
    }
}
