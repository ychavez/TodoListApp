using TodoListApp.Mobile.ViewModels;

namespace TodoListApp.Mobile.Views;

public partial class EditCategoryPage : ContentPage
{
	public EditCategoryPage(EditCategoryViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        nameEntry.InitializeEntry();
        colorEntry.InitializeEntry();

    }
}