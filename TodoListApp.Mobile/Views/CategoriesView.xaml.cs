using TodoListApp.Mobile.ViewModels;

namespace TodoListApp.Mobile.Views;

public partial class CategoriesView : ContentPage
{
	public CategoriesView(CategoriesViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

		if (BindingContext is CategoriesViewModel vm) {

			vm.LoadCategoriesCommand.Execute(null);
		}
    }
}