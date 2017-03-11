using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ShopHelper.Client
{
    public abstract class ViewModel : INotifyPropertyChanged, IDisposable
    {
        public ViewModel(IView view)
        {
            Guard.NotNull(view, nameof(view));
            View = view;
            View.BindingContext = this;
        }

        public IView View { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void InvokePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(field, value))
            {
                return false;
            }
            field = value;
            InvokePropertyChanged(propertyName);
            return true;
        }

        #region IDisposable Support
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    View.BindingContext = null;
                    View = null;
                }

                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }

    public abstract class ViewModel<TView> : ViewModel where TView : IView
    {
        public ViewModel(TView view)
            : base(view)
        {
        }

        public new TView View => (TView)base.View;
    }
}
