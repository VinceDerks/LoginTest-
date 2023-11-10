using Microsoft.Maui.Media;
using System;
using System.ComponentModel;
using System.Security.Claims;
using System.Windows.Input;

namespace LoginTest
{


    public class AppShellViewModel
    {
        public ICommand GoToRoutesCommandPage { get; }
        public AppShellViewModel()
        {
            GoToRoutesCommandPage = new Command(ExecuteGoToRoutesCommandPage);
        }

        private async void ExecuteGoToRoutesCommandPage()
        {
            await Shell.Current.GoToAsync("//RouteDirection");
        }

        public class MainViewModel : INotifyPropertyChanged
        {
            private string _selectedLanguage;

            public string SelectedLanguage
            {
                get { return _selectedLanguage; }
                set
                {
                    if (_selectedLanguage != value)
                    {
                        _selectedLanguage = value;
                        OnPropertyChanged(nameof(SelectedLanguage));
                    }
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}




