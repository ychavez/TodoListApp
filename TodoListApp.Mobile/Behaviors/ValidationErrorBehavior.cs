﻿using System.ComponentModel;
using TodoListApp.Mobile.ViewModels;

namespace TodoListApp.Mobile.Behaviors
{
    public class ValidationErrorBehavior : Behavior<Entry>
    {
        private BaseViewModel? _viewModel;
        private string? _propertyName;
        private bool _isAttached;
        private Entry _entry;

        public static readonly BindableProperty PropertyNameProperty =
            BindableProperty.Create("NombreDePropiedad", typeof(string),
                typeof(ValidationErrorBehavior), string.Empty);


        public string NombreDePropiedad
        {
            get => (string)GetValue(PropertyNameProperty);
            set => SetValue(PropertyNameProperty, value);
        }



        protected override void OnAttachedTo(Entry entry)
        {
            entry.BindingContextChanged += OnBindingContextChanged;
            entry.TextChanged += OnEntryTexChanged;
            _entry = entry;
            base.OnAttachedTo(entry);
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.BindingContextChanged -= OnBindingContextChanged;
            entry.TextChanged -= OnEntryTexChanged;
            base.OnDetachingFrom(entry);
        }

        private void AttachHandlers() 
        {
            if (_isAttached || _viewModel is null) return;

            _viewModel.ErrorsChanged += OnErrorsChanged;

        }

        private void OnErrorsChanged(object sender, DataErrorsChangedEventArgs e) 
        {
        
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
