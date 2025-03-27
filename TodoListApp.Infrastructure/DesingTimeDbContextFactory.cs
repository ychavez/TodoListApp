using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TodoListApp.Infrastructure.DataContext;

namespace TodoListApp.Infrastructure
{
    public class DesingTimeDbContextFactory : IDesignTimeDbContextFactory<TodoListDbContext>
    {
        public TodoListDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TodoListDbContext>();
            optionsBuilder.UseSqlite("Data source=todoLidt.db");

            return new TodoListDbContext(optionsBuilder.Options);
        }
    }
}
