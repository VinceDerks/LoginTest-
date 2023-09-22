using Microsoft.Maui.Controls;

namespace LoginTest
{
    public partial class UserPage : ContentPage
    {
        public UserPage()
        {
            InitializeComponent();
        }

        public UserPage(string username, string password)
        {
            InitializeComponent();
            UsernameLabel.Text = username;
            PasswordLabel.Text = password;
        }
    }
}