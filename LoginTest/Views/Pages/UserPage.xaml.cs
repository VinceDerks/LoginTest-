using LoginTest;
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