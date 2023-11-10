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
        }
    }
}