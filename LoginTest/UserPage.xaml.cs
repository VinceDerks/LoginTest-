using Microsoft.Maui.Controls;

namespace LoginTest
{
    public partial class UserPage : ContentPage
    {
        public UserPage()
        {
            InitializeComponent();
        }

        public UserPage(string username, string password)
        {
            InitializeComponent();
            UsernameLabel.Text = username;
            PasswordLabel.Text = password;
        }

        private void LogoutButton_Clicked(object sender, EventArgs e)
        {
            // Clear stored credentials from secure storage
            SecureStorage.Remove("Username");
            SecureStorage.Remove("Password");

            // Redirect to login page
            Navigation.PopToRootAsync();


        }

        private async void RetrieveName(object sender, EventArgs e)
        {
            string username = await SecureStorage.GetAsync("Username");
            string password = await SecureStorage.GetAsync("Password");


            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                var userDetailsPage = new UserPage(username, password);
                await Navigation.PushAsync(userDetailsPage);
            }
        }

    }
}