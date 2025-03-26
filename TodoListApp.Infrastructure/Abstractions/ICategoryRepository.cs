using TodoListApp.Domain.Entities;
using TodoListApp.Domain.Models;

namespace TodoListApp.Infrastructure.Abstractions
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAll();

        Task<Category?> GetById(long id);

        Task<bool> DeleteById(long id);

        Task<bool> UpdateCategory(Category category);

        Task<Category> CreateCategory(Category category);
    }
}
