using System.ComponentModel.DataAnnotations;
using System.Reflection;
using TodoListApp.Mobile.Behaviors;
using TodoListApp.Mobile.ViewModels;

namespace TodoListApp.Mobile.Components;

public partial class ValidatedEntry : ContentView
{
    public static readonly BindableProperty TextProperty =
          BindableProperty.Create(nameof(Text), typeof(string), typeof(ValidatedEntry), default);

    public static readonly BindableProperty NameProperty =
          BindableProperty.Create(nameof(PropertyName), typeof(string), typeof(ValidatedEntry), default);

    public Label ErrorLabel => this.ErrorLabelInternal;

    public string PropertyName
    {
        get => (string)GetValue(NameProperty);
        set => SetValue(NameProperty, value);
    }
    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    private string PlaceHolder { get; set; }


    public ValidatedEntry()
    {
        InitializeComponent();
        InputEntry.BindingContext = this;
    }

    public BaseViewModel BaseViewModel { get; set; }
    public object Model { get; set; }


    public void InitializeEntry()
    {
        if (Parent?.BindingContext is BaseViewModel baseViewModel)
        {
            BaseViewModel = baseViewModel;
            Model = baseViewModel.Model;
        }

        if (Model is null || string.IsNullOrEmpty(PropertyName))
            return;

        var propertyInfo = Model.GetType().GetProperty(PropertyName);

        var displayAttribute = propertyInfo?.GetCustomAttribute<DisplayAttribute>();
        if (displayAttribute != null)
        {
            PlaceHolder = displayAttribute.Name!;
        }

        InputEntry.Placeholder = PlaceHolder;
        Behaviors.Add(new ValidatedEntryBehavior());

    }
}