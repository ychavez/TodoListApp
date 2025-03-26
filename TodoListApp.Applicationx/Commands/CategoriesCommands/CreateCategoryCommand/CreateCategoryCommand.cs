using MediatR;
using TodoListApp.Domain.Models;

namespace TodoListApp.Applicationx.Commands.CategoriesCommands.CreateCategoryCommand
{
    public class CreateCategoryCommand: IRequest<bool>
    {
        public CategoryModel CategoryModel { get; set; } = null!;
    }
}
