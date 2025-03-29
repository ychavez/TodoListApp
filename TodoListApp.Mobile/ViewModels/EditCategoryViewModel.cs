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
            Model = new CategoryModel();
        }

      
        private readonly IMediator mediator;
        private readonly INavigationService navigationService;

       

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
                ClearAllErrors();


                await mediator.Send(new CreateCategoryCommand
                {
                    CategoryModel = (CategoryModel)Model
                });

                await navigationService.GoBackAsync();
            }
            catch (FluentValidation.ValidationException v) 
            {
                OnErrorsChanged(v);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
