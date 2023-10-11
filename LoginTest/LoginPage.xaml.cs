using LoginTest.Resources.Languages;
using System.Globalization;
using LoginTest.ViewModels;
namespace LoginTest
{
    public partial class LoginPage : ContentPage
    {
        public LocalizationResourceManager localizationResourceManager
            => LocalizationResourceManager.Instance;
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = this;
            
        }

        private void TestButton_Clicked(object sender, EventArgs e)
        {
            var switchToCulture = !AppResources.Culture.TwoLetterISOLanguageName
            .Equals("nl", StringComparison.InvariantCultureIgnoreCase) ?
            new CultureInfo("nl-NL") : new CultureInfo("en-US");

            LocalizationResourceManager.Instance.SetCulture(switchToCulture);
        }
        private void SignInButton_Clicked(object sender, EventArgs e)
        {
            string username = UsernameEntry.Text;
            string password = PasswordEntry.Text;

            if (AuthenticationService.ValidateLogin(username, password))
            { 

                SecureStorage.SetAsync("IsLoggedIn", "true");
                AuthenticationService.SaveCredentials(username, password);
            }
            else
            {
                DisplayAlert("Error", "Invalid username or password", "OK");
            }
        }

        
    }
}