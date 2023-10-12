using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginTest.ViewModels
{
    public partial class AuthenticationService
    {
        public static bool ValidateLogin(string username, string password)
        {
            string specificUsername1 = "Angelo";
            string specificPassword1 = "erven";

            string specificUsername2 = "Geert";
            string specificPassword2 = "erven";

            if ((username == specificUsername1 && password == specificPassword1) ||
                (username == specificUsername2 && password == specificPassword2))
            {
                App.Current.MainPage = new AppShell();
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void SaveCredentials(string username, string password)
        {
            SecureStorage.SetAsync("Username", username);
            SecureStorage.SetAsync("Password", password);
        }

        public static async Task CheckLoginStatus()
        {
            string isLoggedIn = await SecureStorage.GetAsync("IsLoggedIn");
            string username = await SecureStorage.GetAsync("Username");
            string password = await SecureStorage.GetAsync("Password");

            if (isLoggedIn == "true" && !string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                if (ValidateLogin(username, password))
                {
                    if (App.Current.MainPage is AppShell)
                    {
                        return;
                    }
                    else
                    {
                        App.Current.MainPage = new AppShell();
                    }
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Login Failed", "Invalid username or password.", "OK");
                    await SecureStorage.SetAsync("IsLoggedIn", "false"); 
                    App.Current.MainPage = new LoginPage();
                }
            }
            else if (isLoggedIn == "true")
            {

                await App.Current.MainPage.DisplayAlert("Login Failed", "Please enter your username and password.", "OK");
                await SecureStorage.SetAsync("IsLoggedIn", "false"); 
                App.Current.MainPage = new LoginPage();
            }
            else
            {
                App.Current.MainPage = new LoginPage();
            }
        }

    }
}