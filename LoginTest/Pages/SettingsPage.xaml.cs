namespace LoginTest.Pages;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();
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