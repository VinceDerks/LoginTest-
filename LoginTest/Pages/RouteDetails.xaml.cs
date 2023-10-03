using LoginTest.Pages;
using Microsoft.Maui.Controls;
namespace LoginTest
{
    public partial class RouteDetails : ContentPage
    {
        public RouteDetails()
        {
            InitializeComponent();
        }
        private ArrivedPage arrivedPage;

        private void Arrived(object sender, EventArgs e)
        {
            arrivedPage = new ArrivedPage();
            Navigation.PushAsync(arrivedPage);
        }
    }
 }
    