using LoginTest;
using Microsoft.Maui.Controls;
using LoginTest.Model;
using LoginTest.Resources.Languages;
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

        private ArrivedPage arrivedPage;

        private void Arrived(object sender, EventArgs e)
        {
            arrivedPage = new ArrivedPage(SelectedRoute);
            Navigation.PushAsync(arrivedPage);
        }


    }
}
    