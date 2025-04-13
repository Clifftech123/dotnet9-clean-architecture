using AutoMapper;
using MediatR;
using Todo.Application.Commands.Categorys;
using Todo.Application.Exceptions;
using Todo.Domain.Contracts;
using Todo.Domain.Entities;
using Todo.Infrastructure.Interface;

namespace Todo.Application.Handlers.Categorys
{
    public class UpdateTodCategoryHandler : IRequestHandler<UpdateTodoCategoryCommand, ApiResponse>
    {
        private readonly IBaseRepository<TodoCategory> baseRepository;
        private readonly IMapper _mapper;

        public UpdateTodCategoryHandler(IBaseRepository<TodoCategory> baseRepository, IMapper mapper)
        {
            this.baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse> Handle(UpdateTodoCategoryCommand request, CancellationToken cancellationToken)
        {
            var exisingTodoCategory = await baseRepository.GetByIdAsync(request.Id);
            if (exisingTodoCategory == null)
            {
                throw new CategoryNotFoundException(request.Id);
            }

            var categoryToUpdate = _mapper.Map(request.UpdateTodoCategoryRequest, exisingTodoCategory);
            await baseRepository.UpdateAsync(categoryToUpdate);
            var categoryResponseData = _mapper.Map<TodoCategoryDto>(categoryToUpdate);

            return new ApiResponse
            {
                Success = true,
                Data = categoryResponseData,
                Message = "Todo updated successfully"
            };
        }
    }
}
