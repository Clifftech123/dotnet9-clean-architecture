using AutoMapper;
using MediatR;
using Todo.Application.Commands.Categorys;
using Todo.Domain.Contracts;
using Todo.Domain.Entities;
using Todo.Infrastructure.Interface;

namespace Todo.Application.Handlers.Categorys
{
    public class CreateTodoCategoryHandler : IRequestHandler<CreateTodoCategoryCommand, ApiResponse>
    {
        private readonly IBaseRepository<TodoCategory> baseRepository;
        private readonly IMapper _mapper;

        public CreateTodoCategoryHandler(IBaseRepository<TodoCategory> baseRepository, IMapper mapper)
        {
            this.baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse> Handle(CreateTodoCategoryCommand request, CancellationToken cancellationToken)
        {


            var category = _mapper.Map<TodoCategory>(request.CreateTodoCategoryRequest);
            if (category == null)
            {
                throw new InvalidDataException("Invalid data");
            }


            await baseRepository.AddAsync(category);

            var todoResponseData = _mapper.Map<TodoCategory>(category);

            return new ApiResponse
            {
                Data = todoResponseData,
                Success = true,
                Message = "Todo created successfully"
            };


        }
    }
}
