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
            SecureStorage.Remove("username");
            SecureStorage.Remove("password");

            // Redirect to login page
            Navigation.PopToRootAsync();
        }
    }
}