using FluentValidation;
using TodoListApp.Applicationx.Commands.CategoriesCommands.CreateCategoryCommand;

namespace TodoListApp.Applicationx.Validations.Category
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryValidator()
        {
            RuleFor(x => x.CategoryModel.Name)
                .NotEmpty().WithMessage("El nombre no puede ir vacio")
                .NotNull().WithMessage("El nombre no puede ir vacio")
                .MinimumLength(3).WithMessage("la categoria tiene que contener mas de 2 caracteres")
                .MaximumLength(10);

            RuleFor(x => x.CategoryModel.Color)
                .GreaterThan(0);

            RuleFor(x => x.CategoryModel.Apodo).NotEmpty();
        }
    }
}
