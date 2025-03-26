using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListApp.Domain.Models;
using TodoListApp.Infrastructure.Abstractions;

namespace TodoListApp.Applicationx.Queries.CategoriesQueries.GetAll
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<CategoryModel>>
    {
        private readonly ICategoryRepository categoryRepository;

        public GetAllCategoriesQueryHandler(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public async Task<IEnumerable<CategoryModel>> Handle(GetAllCategoriesQuery request,
            CancellationToken cancellationToken)
        {
            var categories = await categoryRepository.GetAll();

            var categoryModels = categories.Select(c => new CategoryModel
            {
                Id = c.Id,
                Name = c.Name,
                Color = c.Color
            });

            return categoryModels;
        }
    }
}
