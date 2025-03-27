using MediatR;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TodoListApp.Applicationx.Commands.CategoriesCommands.CreateCategoryCommand;
using TodoListApp.Applicationx.Queries.CategoriesQueries.GetAll;
using TodoListApp.Applicationx.Services.Abstractions;
using TodoListApp.Domain.Models;
using TodoListApp.Mobile.Views;

namespace TodoListApp.Mobile.ViewModels
{
    public class CategoriesViewModel : BaseViewModel
    {
        private readonly IMediator mediator;
        private readonly INavigationService navigationService;


        public ICommand LoadCategoriesCommand { get; set; }
        public ICommand CreateCategoryCommand { get; set; }

        public ICommand EditCategoryCommand { get; set; }

        private ObservableCollection<CategoryModel> _categories = new();
        public ObservableCollection<CategoryModel> Categories
        {
            get => _categories;
            set => SetProperty(ref _categories, value);
        }

        public CategoriesViewModel(IMediator mediator, INavigationService navigationService)
        {
            this.mediator = mediator;
            this.navigationService = navigationService;
            LoadCategoriesCommand = new Command(async () => await LoadCategoryAsync());
            CreateCategoryCommand = new Command(async () => await CreateCategory());
        }

        private async Task CreateCategory() 
        {
           await navigationService.NavigateToAsync(typeof(EditCategoryPage));
        }

        private async Task LoadCategoryAsync()
        {
            if (IsBusy) return;

            try
            {
                IsBusy = true;

                var categories = await mediator.Send(new GetAllCategoriesQuery());
                Categories = new ObservableCollection<CategoryModel>(categories);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }

       
    }
}
