using MediatR;
using System.Windows.Input;
using TodoListApp.Applicationx.Commands.CategoriesCommands.CreateCategoryCommand;
using TodoListApp.Applicationx.Services.Abstractions;
using TodoListApp.Domain.Entities;
using TodoListApp.Domain.Models;

namespace TodoListApp.Mobile.ViewModels
{
    public class EditCategoryViewModel : BaseViewModel
    {
        public EditCategoryViewModel(IMediator mediator, INavigationService navigationService)
        {
            this.mediator = mediator;
            this.navigationService = navigationService;
            SaveCommand = new Command(async () => await Save());
            CancelCommand = new Command(async () => await Cancel());
        }

        private Category _currentCategory = new();
        private readonly IMediator mediator;
        private readonly INavigationService navigationService;

        public Category CurrentCategory
        {
            get => _currentCategory;
            set => SetProperty(ref _currentCategory, value);
        }

        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        private async Task Cancel()
        {
            await navigationService.GoBackAsync();
        }

        private async Task Save()
        {
            if (IsBusy) return;
            try
            {
                IsBusy = true;
                if (string.IsNullOrEmpty(CurrentCategory.Name))
                {
                    Errors[nameof(CurrentCategory.Name)] = new List<string> { "El nombre es requerido" };
                    OnErrorsChanged(nameof(CurrentCategory.Name));
                    return;
                }

                await mediator.Send(new CreateCategoryCommand
                {
                    CategoryModel =
                    new CategoryModel
                    {
                        Name = CurrentCategory.Name,
                        Color = CurrentCategory.Color,

                    }
                });

                await navigationService.GoBackAsync();
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
