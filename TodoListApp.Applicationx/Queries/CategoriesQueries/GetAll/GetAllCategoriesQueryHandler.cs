using AutoMapper;
using MediatR;
using TodoListApp.Domain.Models;
using TodoListApp.Infrastructure.Abstractions;

namespace TodoListApp.Applicationx.Queries.CategoriesQueries.GetAll
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<CategoryModel>>
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public GetAllCategoriesQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<CategoryModel>> Handle(GetAllCategoriesQuery request,
            CancellationToken cancellationToken)
        {
            var categories = await categoryRepository.GetAll();

            var result = mapper.Map<IEnumerable<CategoryModel>>(categories);
            
            return result;
           
        }

    }
}
