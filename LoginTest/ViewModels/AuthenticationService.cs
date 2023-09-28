using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginTest.ViewModels
{
    public class AuthenticationService
    {
        private static bool ValidateLogin(string username, string password)
        {
            string specificUsername1 = "Angelo";
            string specificPassword1 = "erven";

            string specificUsername2 = "Geert";
            string specificPassword2 = "erven";

            if ((username == specificUsername1 && password == specificPassword1) ||
                (username == specificUsername2 && password == specificPassword2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static async Task CheckLoginStatus()
        {
            if (await SecureStorage.GetAsync("IsLoggedIn") == "true" && ValidateLogin(await SecureStorage.GetAsync("Username"), await SecureStorage.GetAsync("Password")))
            {

                App.Current.MainPage = new NavigationPage(new RoutesPage());
            }
            else
            {
                App.Current.MainPage = new NavigationPage(new LoginPage());
            }
        }

    }
}