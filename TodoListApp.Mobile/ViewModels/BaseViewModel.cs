using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TodoListApp.Mobile.ViewModels
{
    internal abstract class BaseViewModel : INotifyPropertyChanged, INotifyDataErrorInfo
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

        protected void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        protected void ClearAllErrors()
        {
            Errors.Clear();
            OnErrorsChanged(string.Empty);

        }
        #endregion
    }
}
