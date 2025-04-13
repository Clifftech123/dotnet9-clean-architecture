using AutoMapper;
using MediatR;
using Todo.Application.Queries.Categorys;
using Todo.Domain.Contracts;
using Todo.Domain.Entities;
using Todo.Infrastructure.Interface;

namespace Todo.Application.Handlers.Categorys
{
    public class GetAllTodoCategorQueryHandler : IRequestHandler<GetAllTodoCategoriesQuery, ApiResponse>
    {
        private readonly IBaseRepository<TodoCategory> baseRepository;
        private readonly IMapper _mapper;

        public GetAllTodoCategorQueryHandler(IBaseRepository<TodoCategory> baseRepository, IMapper mapper)
        {
            this.baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse> Handle(GetAllTodoCategoriesQuery request, CancellationToken cancellationToken)
        {
            var getAllTodoCategories = await baseRepository.GetAllAsync();
            if (getAllTodoCategories == null || !getAllTodoCategories.Any())
            {
                return new ApiResponse
                {
                    Success = false,
                    Message = "No Todo found",
                    Data = new List<TodoCategory>()
                };

            }


            var result = _mapper.Map<List<TodoCategoryDto>>(getAllTodoCategories);
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
