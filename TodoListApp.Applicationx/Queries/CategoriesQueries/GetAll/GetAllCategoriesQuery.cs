using MediatR;
using TodoListApp.Domain.Models;

namespace TodoListApp.Applicationx.Queries.CategoriesQueries.GetAll
{
    public class GetAllCategoriesQuery: IRequest<IEnumerable<CategoryModel>>
    {
    }
}
