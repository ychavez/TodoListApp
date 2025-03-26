using MediatR;
using TodoListApp.Domain.Entities;
using TodoListApp.Infrastructure.Abstractions;

namespace TodoListApp.Applicationx.Commands.CategoriesCommands.CreateCategoryCommand
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, bool>
    {
        private readonly ICategoryRepository categoryRepository;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public async Task<bool> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
           //TODO: validar no duplicado

            var category = new Category
            {
                Color = request.CategoryModel.Color,
                Name = request.CategoryModel.Name,
                IsDeleted = false
            };

            await categoryRepository.CreateCategory(category);
            
            return true;
        }
    }
}
