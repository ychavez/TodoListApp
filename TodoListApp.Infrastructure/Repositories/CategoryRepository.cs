using Microsoft.EntityFrameworkCore;
using TodoListApp.Domain.Entities;
using TodoListApp.Infrastructure.Abstractions;
using TodoListApp.Infrastructure.DataContext;

namespace TodoListApp.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly TodoListDbContext todoListDbContext;

        public CategoryRepository(TodoListDbContext todoListDbContext)
        {
            this.todoListDbContext = todoListDbContext;
        }

        public async Task<bool> DeleteById(long id)
        {
            var category = await todoListDbContext.Categories.FindAsync(id);

            if (category == null || category.IsDeleted)
                return false;

            category.IsDeleted = true;
            await todoListDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Category>> GetAll()
           => await todoListDbContext
            .Categories
            .Where(x => !x.IsDeleted)
            .ToListAsync();


        public async Task<Category?> GetById(long id)
        {
            return await todoListDbContext
                .Categories
                .SingleOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
        }

        public async Task<bool> UpdateCategory(Category category)
        {
            var existingCategory = await GetById(category.Id);

            if (existingCategory == null)
                return false;

            todoListDbContext.Entry(existingCategory).CurrentValues.SetValues(category);

            await todoListDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Category> CreateCategory(Category category)
        {
            todoListDbContext.Categories.Add(category);
            await todoListDbContext.SaveChangesAsync();
            return category;
        }
    }
}
