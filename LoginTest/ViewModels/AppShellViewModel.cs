using Microsoft.Maui.Media;
using System;
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
    }
}




