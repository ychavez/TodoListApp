using Microsoft.EntityFrameworkCore;
using TodoListApp.Domain.Entities;

namespace TodoListApp.Infrastructure.DataContext
{
    public class TodoListDbContext: DbContext
    {
        public TodoListDbContext(DbContextOptions<TodoListDbContext> options):base(options) { }
        
        public DbSet<Category> Categories { get; set; }
        
    }
}
