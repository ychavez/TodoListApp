using TodoListApp.Applicationx.Behaviors;

namespace TodoListApp.Mobile.Components;

public partial class ValidatedEntry : ContentView
{
    public static readonly BindableProperty TextProperty =
          BindableProperty.Create("Text", typeof(string), typeof(ValidatedEntry), default);

    public static readonly BindableProperty PlaceHolderProperty =
        BindableProperty.Create("PlaceHolder", typeof(string), typeof(ValidatedEntry), default);


    public string Text 
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);  
    }

    public string PlaceHolder
    {
        get => (string)GetValue(PlaceHolderProperty);
        set => SetValue(PlaceHolderProperty, value);
    }


    public ValidatedEntry()
    {
        InitializeComponent();
        InputEntry.BindingContext = this;

    }
}