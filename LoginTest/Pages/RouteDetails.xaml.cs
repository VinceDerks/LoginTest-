using LoginTest;
using Microsoft.Maui.Controls;
using LoginTest.Model;
using LoginTest.Resources.Languages;
namespace LoginTest
{
    public partial class RouteDetails : ContentPage
{
    public RoutesSrc SelectedRoute { get; set; }

    public RouteDetails(RoutesSrc selectedRoute)
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
    