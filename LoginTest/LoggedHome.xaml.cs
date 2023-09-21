using Microsoft.Maui.Controls;

namespace LoginTest
{
    public partial class LoggedHome : ContentPage
    {
        public LoggedHome()
        {
            InitializeComponent();
            RetrieveName();
        }

        private void LogoutButton_Clicked(object sender, EventArgs e)
        {
            // Clear stored credentials from secure storage
            SecureStorage.Remove("Username");
            SecureStorage.Remove("Password");

            // Redirect to login page
            Navigation.PopToRootAsync();


        }

        private async void RetrieveName()
        {
            bobbert.Text = await SecureStorage.GetAsync("Username");

            Home.Text =  await SecureStorage.GetAsync("Username");
        }
    }
}