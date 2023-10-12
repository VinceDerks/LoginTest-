using LoginTest.Pages;
using Microsoft.Maui.Controls;

namespace LoginTest
{
    public partial class UserPage : ContentPage
    {
        public UserPage()
        {
            InitializeComponent();
            RetrieveName();
            
        }

        private async void LogoutButton_Clicked(object sender, EventArgs e)
        {
            SecureStorage.Remove("IsLoggedIn");
            SecureStorage.Remove("Username");
            SecureStorage.Remove("Password");

            var LoginPage = new LoginPage();
            await Navigation.PushAsync(LoginPage);
            Navigation.RemovePage(this);
        }

        private async void RetrieveName()
        {
            string username = await SecureStorage.GetAsync("Username");
            string password = await SecureStorage.GetAsync("Password");

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                UsernameLabel.Text = username;
                PasswordLabel.Text = password;
            }
        }

        private async void NavToSettingsPage(object sender, EventArgs e)
        {
            var SettingsPage = new SettingsPage();
            await Navigation.PushAsync(SettingsPage);
        }


    }
}