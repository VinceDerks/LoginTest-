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
                        // User is already logged in and using the AppShell
                        return;
                    }
                    else
                    {
                        // User is logged in, set the AppShell as MainPage
                        App.Current.MainPage = new AppShell();
                    }
                }
                else
                {
                    // Handle case when username or password validation fails
                    await App.Current.MainPage.DisplayAlert("Login Failed", "Invalid username or password.", "OK");
                    await SecureStorage.SetAsync("IsLoggedIn", "false"); // Reset login status
                    App.Current.MainPage = new LoginPage();
                }
            }
            else if (isLoggedIn == "true")
            {
                // Handle case when username or password is not set
                await App.Current.MainPage.DisplayAlert("Login Failed", "Please enter your username and password.", "OK");
                await SecureStorage.SetAsync("IsLoggedIn", "false"); // Reset login status
                App.Current.MainPage = new LoginPage();
            }
            else
            {
                // User is not logged in, set the LoginPage as MainPage
                App.Current.MainPage = new LoginPage();
            }
        }

    }
}