using TodoListApp.Mobile.Components;
using TodoListApp.Mobile.ViewModels;

namespace TodoListApp.Mobile.Behaviors
{
    public class ValidatedEntryBehavior : Behavior<ValidatedEntry>
    {

        protected override void OnAttachedTo(ValidatedEntry bindable)
        {
            base.OnAttachedTo(bindable);

            var viewModel = bindable.BaseViewModel;

            if (viewModel is not null)
            {
                viewModel.ErrorsChanged += (sender, args) =>
                {

                    UpdateErrorState(bindable, viewModel);
                };

            }
        }

        protected override void OnDetachingFrom(ValidatedEntry bindable)
        {
            base.OnDetachingFrom(bindable);

            var viewModel = bindable.BaseViewModel;

            if (viewModel is not null)
            {
                viewModel.ErrorsChanged -= (sender, args) =>
                {

                    UpdateErrorState(bindable, viewModel);
                };

            }
        }

        private void UpdateErrorState(ValidatedEntry entry, BaseViewModel baseViewModel)
        {

            var modelName = baseViewModel.Model.GetType().Name;

            var errors = (IEnumerable<string>)baseViewModel.GetErrors($"{modelName}.{entry.PropertyName}");

            if (errors.Any())
            {
                entry.ErrorLabel.Text = errors.First();
                entry.ErrorLabel.IsVisible = true;
                return;
            }
            entry.ErrorLabel.IsVisible = false;

        }
    }
}
