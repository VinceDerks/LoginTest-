using LoginTest.Resources.Languages;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls;
using System;
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
            

            DarkModeSwitch.IsToggled = darkMode;

            DarkModeSwitch.Toggled += DarkModeSwitch_Toggled;

            LanguagePicker.SelectedIndexChanged += LanguagePicker_SelectedIndexChanged;
        }

        private void DarkModeSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            DarkMode = e.Value;

            Preferences.Set("DarkMode", darkMode.ToString());

        }


        private void LanguagePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedLanguage = LanguagePicker.SelectedItem.ToString();
            ChangeAppLanguage(selectedLanguage);
         
        }

        private void ChangeAppLanguage(string selectedLanguage)
        {
            if (selectedLanguage == "English")
            {
                AppResources.Culture = new System.Globalization.CultureInfo("en-US");
            }
            else if (selectedLanguage == "Nederlands")
            {
                AppResources.Culture = new System.Globalization.CultureInfo("nl-NL");
            }

            Preferences.Set("SelectedLanguage", selectedLanguage);

            ReloadApp();

        }

        private void ReloadApp()
        {
            Application.Current.MainPage = new AppShell();
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