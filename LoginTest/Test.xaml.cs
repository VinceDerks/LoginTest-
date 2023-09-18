namespace LoginTest;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    public void LoginClicked(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new NewPage1());
    }
}
}