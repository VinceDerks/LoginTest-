using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace LoginTest
{
    public partial class SettingsPage : ContentPage
    {
        private bool darkMode = false;

        public bool DarkMode
        {
            get { return darkMode; }
            set
            {
                darkMode = value;
                Application.Current.UserAppTheme = darkMode ? AppTheme.Dark : AppTheme.Light;
            }
        }

        public SettingsPage()
        {
            InitializeComponent();

            darkMode = Application.Current.UserAppTheme == AppTheme.Dark;
            DarkModeSwitch.IsToggled = darkMode;

            DarkModeSwitch.Toggled += DarkModeSwitch_Toggled;
        }

        private void DarkModeSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            DarkMode = e.Value;
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
    }
}
