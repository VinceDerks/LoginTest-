using LoginTest;
using Microsoft.Maui.Controls;
using LoginTest.Model;
using LoginTest.Resources.Languages;
using Xamarin.Essentials;

namespace LoginTest
{
    public partial class RouteDetails : ContentPage
{
    public Destination SelectedRoute { get; set; }

        public RouteDetails(Destination selectedRoute)
        {
            InitializeComponent();
            SelectedRoute = selectedRoute;
            BindingContext = this;
        }

        private void CallNumber(object sender, EventArgs e)
        {
            if (Microsoft.Maui.ApplicationModel.Communication.PhoneDialer.IsSupported)
                Microsoft.Maui.ApplicationModel.Communication.PhoneDialer.Open(SelectedRoute.ContactPhone);
        }

        private void Arrived(object sender, EventArgs e)
        {
           
            Navigation.PushAsync(new ItemsPage(SelectedRoute));
        }

        private async void OpenMaps(object sender, EventArgs e)
        {
            string address = SelectedRoute.Adress;
            if (!string.IsNullOrEmpty(address))
            {
                try
                {
                    // Launch the maps app with the specified address
                    await Microsoft.Maui.ApplicationModel.Launcher.OpenAsync($"https://maps.google.com/?q={Uri.EscapeDataString(address)}");
                }
                catch (Exception ex)
                {
                    // Handle any errors that may occur
                    Console.WriteLine($"Unable to open maps app: {ex.Message}");
                }
            }
        }

    }
}
    