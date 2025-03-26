using TodoListApp.Mobile.ViewModels;

namespace TodoListApp.Mobile;

public partial class HelloWorldPage : ContentPage
{
	public HelloWorldPage(HelloWorldViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}