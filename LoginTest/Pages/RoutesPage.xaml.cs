using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace LoginTest
{
    public partial class RoutesPage : ContentPage
    {
        public ICommand ShowDetailsCommand { get; }

        public RoutesPage()
        {
            InitializeComponent();
            BindingContext = this;

            ShowDetailsCommand = new Command<string>(ShowDetails);
        }

        private void ShowDetails(string routeId)
        {
            // Navigate to the details page with the selected route ID
            // You can use the Navigation service provided by .NET MAUI
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Populate the Routes collection with sample data or retrieve it from a data source
            routes = new ObservableCollection<Route>()
            {
                new Route() { ID = "1", Location = "Location 1", DateTime = new DateTime(2022, 12, 31, 10, 0, 0) },
                new Route() { ID = "2", Location = "Location 2", DateTime = new DateTime(2022, 12, 30, 14, 30, 0) },
                new Route() { ID = "3", Location = "Location 3", DateTime = new DateTime(2022, 12, 29, 16, 0, 0) },
                new Route() { ID = "4", Location = "Location 4", DateTime = new DateTime(2022, 12, 28, 9, 0, 0) },
            };

            // Sort the Routes collection by date and time in ascending order
            routes = new ObservableCollection<Route>(routes.OrderBy(r => r.DateTime));

            // Remove routes that have already passed
            routes = new ObservableCollection<Route>(routes.Where(r => r.DateTime > DateTime.Now));
        }

        public ObservableCollection<Route> routes { get; private set; }
    }
}