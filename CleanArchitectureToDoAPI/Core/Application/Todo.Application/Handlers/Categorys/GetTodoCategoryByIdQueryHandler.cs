using AutoMapper;
using MediatR;
using Todo.Application.Exceptions;
using Todo.Application.Queries.Categorys;
using Todo.Domain.Contracts;
using Todo.Domain.Entities;
using Todo.Infrastructure.Interface;

namespace Todo.Application.Handlers.Categorys
{
    public class GetTodoCategoryByIdQueryHandler : IRequestHandler<GetTodoCategoryByIdQuery, ApiResponse>
    {
        private readonly IBaseRepository<TodoCategory> baseRepository;
        private readonly IMapper _mapper;

        public GetTodoCategoryByIdQueryHandler(IBaseRepository<TodoCategory> baseRepository, IMapper mapper)
        {
            this.baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse> Handle(GetTodoCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var getTodoCategoryById = await baseRepository.GetByIdAsync(request.CategoryId);
            if (getTodoCategoryById == null)
            {
                throw new CategoryNotFoundException(request.CategoryId);
            }

            var result = _mapper.Map<TodoCategoryDto>(getTodoCategoryById);
            return new ApiResponse
            {
                Success = true,
                Data = result,
                Message = "Todo fetched successfully"

            };
        }
    }
}
