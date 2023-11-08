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
                // Pas het thema van de app aan op basis van de waarde van DarkMode
                Application.Current.UserAppTheme = darkMode ? AppTheme.Dark : AppTheme.Light;
            }
        }

        public SettingsPage()
        {
            InitializeComponent();

            // Controleer en stel de huidige themamodus in bij het starten van de pagina
            darkMode = Application.Current.UserAppTheme == AppTheme.Dark;
            DarkModeSwitch.IsToggled = darkMode;

            // Voeg een eventhandler toe voor de schakelaar
            DarkModeSwitch.Toggled += DarkModeSwitch_Toggled;
        }

        private void DarkModeSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            // Schakel tussen lichte en donkere modus wanneer de schakelaar wordt omgezet
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
