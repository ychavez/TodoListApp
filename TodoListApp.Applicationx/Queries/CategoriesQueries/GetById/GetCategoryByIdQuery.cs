using MediatR;
using TodoListApp.Domain.Models;

namespace TodoListApp.Applicationx.Queries.CategoriesQueries.GetById
{
    public class GetCategoryByIdQuery: IRequest<CategoryModel?>
    {
        public long Id { get; set; }
    }
}
