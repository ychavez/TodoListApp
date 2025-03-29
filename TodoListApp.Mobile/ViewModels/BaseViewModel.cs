using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TodoListApp.Mobile.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged, INotifyDataErrorInfo
    {

        public event PropertyChangedEventHandler? PropertyChanged;
        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        #region NotifyPropertyChanged
        bool _isBusy;

        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);

        }

        object _model;

        public object Model
        {
            get => _model;
            set => SetProperty(ref _model, value);
        }

        protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            OnPropertyChanged(propertyName);
            return true;

        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
        #endregion

        #region NotifyErrors
        public Dictionary<string, List<string>> Errors { get; } = new();

        public bool HasErrors => Errors.Any();

        public IEnumerable GetErrors(string? propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
                return Errors.SelectMany(e => e.Value);

            return Errors.TryGetValue(propertyName, out var errors)
                ? errors
                : Enumerable.Empty<string>();

        }

        protected void OnErrorsChanged(FluentValidation.ValidationException? exception)
        {
            if (exception is null)
            {
                Errors.Clear();
                ErrorsChanged?.Invoke(this, new(string.Empty));
                return;
            }

            var errorsResult = exception.Errors
                .Where(e => e != null)
                .Select(x => new { x.PropertyName, x.ErrorMessage })
                .ToList();

            foreach (var error in errorsResult)
            {
                Errors[error.PropertyName] = [error.ErrorMessage];
                ErrorsChanged?.Invoke(this, new(error.PropertyName));
            }
        }

        protected void ClearAllErrors()
        {
            Errors.Clear();
            OnErrorsChanged(null);

        }
        #endregion
    }
}
