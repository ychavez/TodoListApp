using MediatR;
using TodoListApp.Domain.Models;
using TodoListApp.Infrastructure.Abstractions;

namespace TodoListApp.Applicationx.Queries.CategoriesQueries.GetById
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryModel?>
    {
        private readonly ICategoryRepository categoryRepository;

        public GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public async Task<CategoryModel?> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await categoryRepository.GetById(request.Id);

            if (category == null)
                return null;

            return new CategoryModel
            {
                Id = category.Id,
                Color = category.Color,
                Name = category.Name
            };
        }
    }
}
