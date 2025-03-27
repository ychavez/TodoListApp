using TodoListApp.Mobile.ViewModels;

namespace TodoListApp.Mobile.Views;

public partial class EditCategoryPage : ContentPage
{
	public EditCategoryPage(EditCategoryViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}