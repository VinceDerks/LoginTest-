using LoginTest.Resources.Languages;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls;
using System;

namespace LoginTest
{
    public partial class SettingsPage : ContentPage
    {


        public SettingsPage()
        {
            InitializeComponent();
            LanguagePicker.SelectedIndexChanged += LanguagePicker_SelectedIndexChanged;
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

            SecureStorage.SetAsync("SelectedLanguage", selectedLanguage);

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