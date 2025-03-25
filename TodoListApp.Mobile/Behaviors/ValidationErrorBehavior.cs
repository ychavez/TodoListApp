using TodoListApp.Mobile.ViewModels;

namespace TodoListApp.Mobile.Behaviors
{
    public class ValidationErrorBehavior : Behavior<Entry>
    {
        private BaseViewModel? _viewModel;
        private string? _propertyName;

        protected override void OnAttachedTo(Entry entry)
        {
            entry.BindingContextChanged += OnBindingContextChanged;
            entry.TextChanged += OnEntryTexChanged;
            
            base.OnAttachedTo(entry);
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.BindingContextChanged -= OnBindingContextChanged;
            entry.TextChanged -= OnEntryTexChanged;
            base.OnDetachingFrom(entry);
        }

        private void OnBindingContextChanged(object sender, EventArgs e)
        {
            if (sender is Entry entry)
            {
                _viewModel = entry.BindingContext as BaseViewModel;

                var binding = entry.BindingContext as Binding;
                _propertyName = binding?.Path;
            }
        }


        private void OnEntryTexChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is Entry entry && _viewModel is not null && !string.IsNullOrEmpty(_propertyName))
            {
                if (_viewModel.Errors.ContainsKey(_propertyName))
                {
                    entry.TextColor = Colors.Red;
                    return;
                }

                entry.TextColor = Colors.Black;
            }
        }
    }
}
