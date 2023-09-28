namespace LoginTest
{
    public partial class App : Application
    {
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