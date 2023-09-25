using Microsoft.Maui.Controls;

namespace LoginTest
{
   public partial class LoggedHome : ContentPage
    {
        public LoggedHome()
        {
            InitializeComponent();
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

            bobbert.Text = username;

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                var userDetailsPage = new UserPage(username, password);
                await Navigation.PushAsync(userDetailsPage);
            }
        }

        private async void NavigateToRoutes(object sender, EventArgs e)
        {
            // Logic to navigate to the RoutesPage
            var routesPage = new RoutesPage();
            await Navigation.PushAsync(routesPage);
        }
    }
}