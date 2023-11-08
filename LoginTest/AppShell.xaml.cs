using LoginTest;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace LoginTest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            BindingContext = new AppShellViewModel();
        }
    }
}