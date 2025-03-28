using AutoMapper;
using MediatR;
using TodoListApp.Domain.Entities;
using TodoListApp.Infrastructure.Abstractions;

namespace TodoListApp.Applicationx.Commands.CategoriesCommands.CreateCategoryCommand
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, bool>
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository,IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }
        public async Task<bool> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
           //TODO: validar no duplicado

            var category = mapper.Map<Category>(request.CategoryModel);

            await categoryRepository.CreateCategory(category);
            
            return true;
        }
    }
}
