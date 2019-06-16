using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MusicMobile.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        bool isBusy;

        public bool IsBusy
        {
            get => isBusy;
            set { isBusy = value; RaisePropertyChanged(); }
        }

        protected void RaisePropertyChanged([CallerMemberName]  string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}
