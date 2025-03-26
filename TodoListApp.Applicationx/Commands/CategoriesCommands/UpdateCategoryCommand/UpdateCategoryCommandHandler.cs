using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListApp.Domain.Entities;
using TodoListApp.Domain.Models;
using TodoListApp.Infrastructure.Abstractions;

namespace TodoListApp.Applicationx.Commands.CategoriesCommands.UpdateCategoryCommand
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, bool>
    {
        private readonly ICategoryRepository categoryRepository;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public async Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
           var category = await categoryRepository.GetById(request.CategoryModel.Id);
            if (category == null)
                return false;

            category.Color = request.CategoryModel.Color;
            category.Name = request.CategoryModel.Name;

            return await categoryRepository.UpdateCategory(category);
        }
    }
}
