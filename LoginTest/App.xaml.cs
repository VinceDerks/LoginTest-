using LoginTest.Resources.Languages;
using static LoginTest.AppShellViewModel;

namespace LoginTest
{
    public partial class App : Application
    {
        public static MainViewModel ViewModel { get; } = new MainViewModel();
        public App()
        {
            InitializeComponent();
        }
       
        protected override async void OnStart()
        {
            await ViewModels.AuthenticationService.CheckLoginStatus();



            string selectedLanguage = Preferences.Get("SelectedLanguage", "Invalid");
            if (selectedLanguage != "Invalid") {

                if (selectedLanguage == "English")
                {
                    AppResources.Culture = new System.Globalization.CultureInfo("en-US");
                }
                else if (selectedLanguage == "Nederlands")
                {
                    AppResources.Culture = new System.Globalization.CultureInfo("nl-NL");
                }
            }

       

            // Retrieve the darkMode value
            string darkModeString = Preferences.Get("DarkMode", "fotnite");
            if (darkModeString != "fotnite")
            {
                bool darkMode = bool.Parse(darkModeString);
                Application.Current.UserAppTheme = darkMode ? AppTheme.Dark : AppTheme.Light;
            }



        }

    }
}