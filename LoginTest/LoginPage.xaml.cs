using Microsoft.Maui.Controls;
using System;

namespace LoginTest
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            CheckLoginStatus();
        }

        private async void CheckLoginStatus()
        {
            if (Preferences.ContainsKey("IsLoggedIn"))
            {
                bool isLoggedIn = Preferences.Get("IsLoggedIn", false);

                if (isLoggedIn)
                {
                    await Navigation.PushAsync(new LoggedHome());
                    Navigation.RemovePage(this);
                }
            }
        }

        private void SignInButton_Clicked(object sender, EventArgs e)
        {
            string username = UsernameEntry.Text;
            string password = PasswordEntry.Text;

            if (ValidateLogin(username, password))
            {
                SaveCredentials(username, password);
                SecureStorage.SetAsync("IsLoggedIn", "true");
                Navigation.PushAsync(new LoggedHome());
                Navigation.RemovePage(this);
            }
            else
            {
                DisplayAlert("Error", "Invalid username or password", "OK");
            }
        }

        private bool ValidateLogin(string username, string password)
        {
            string specificUsername = "mark";
            string specificPassword = "mark";

            return (username == specificUsername && password == specificPassword);
        }

        private void SaveCredentials(string username, string password)
        {
            SecureStorage.SetAsync("Username", username);
            SecureStorage.SetAsync("Password", password);
        }
    }
}