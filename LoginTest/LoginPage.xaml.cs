using Microsoft.Maui.Controls;
namespace LoginTest
{
    public partial class LoginPage : ContentPage
    {

        public LoginPage()
        {
            InitializeComponent();
            CheckLoginStatus();
        }

        private async void CheckLoginStatus()
        {
            if (Preferences.ContainsKey("IsLoggedIn"))
            {
                bool isLoggedIn = Preferences.Get("IsLoggedIn", false);

                if (isLoggedIn)
                {
                    await Navigation.PushAsync(new LoggedHome());
                    Navigation.RemovePage(this);
                }
            }
        }

        private void SignInButton_Clicked(object sender, EventArgs e)
        {
            string username = UsernameEntry.Text;
            string password = PasswordEntry.Text;

            if (ValidateLogin(username, password))
            { 

                SecureStorage.SetAsync("IsLoggedIn", "true");
                SaveCredentials(username, password);
                Navigation.PushAsync(new LoggedHome());
                Navigation.RemovePage(this);
                
            }
            else
            {
                DisplayAlert("Error", "Invalid username or password", "OK");
            }
        }

        private bool ValidateLogin(string username, string password)
        {
            string specificUsername1 = "Angelo";
            string specificPassword1 = "erven";

            string specificUsername2 = "Geert";
            string specificPassword2 = "erven";

            if ((username == specificUsername1 && password == specificPassword1) ||
                (username == specificUsername2 && password == specificPassword2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

            private void SaveCredentials(string username, string password)
        {
            SecureStorage.SetAsync("Username", username);
            SecureStorage.SetAsync("Password", password);
        }
    }
}