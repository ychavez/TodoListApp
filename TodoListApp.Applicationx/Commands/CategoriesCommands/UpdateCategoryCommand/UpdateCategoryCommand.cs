using MediatR;
using TodoListApp.Domain.Models;

namespace TodoListApp.Applicationx.Commands.CategoriesCommands.UpdateCategoryCommand
{
    public class UpdateCategoryCommand : IRequest<bool>
    {
        public CategoryModel CategoryModel { get; set; } = null!;
    }
}
