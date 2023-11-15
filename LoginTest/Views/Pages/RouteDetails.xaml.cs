using LoginTest;
using Microsoft.Maui.Controls;
using LoginTest.Model;
using LoginTest.Resources.Languages;
using LoginTest.Views.Pages;

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

        private ItemsPage ordersPage;

        private void Arrived(object sender, EventArgs e)
        {
            ordersPage = new ItemsPage(SelectedRoute);
            Navigation.PushAsync(ordersPage);
        }


    }
}
    