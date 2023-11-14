using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;
using Newtonsoft.Json;
using System.IO;
using LoginTest.Model;
using System.Linq;

namespace LoginTest
{
    public partial class RoutesPage : ContentPage
    {
        private int routeId;

        public static ContentPage RootPage { get; set; }

        public RoutesPage() 
        {
            InitializeComponent();

        }

        public RoutesPage(int routeId) : this() 
        {
            this.routeId = routeId;
            DisplayDestinations(routeId);
            RootPage = this;
        }
        private List<Destination> FetchRoutesForId(int routeId)
        {
            string jsonData = @"[
        {
            ""ID"": ""1"",
            ""Date"": ""2023-11-10"",
            ""City"": ""Tilburg"",
            ""Address"": ""Distelweg 52"",
            ""TimeArrive"": ""10:00 PM"",
            ""TimeDepart"": ""18:00 PM"",
            ""TypeOf"": ""Delivery"",
            ""Status"": ""Not completed"",
        },
        {
            ""ID"": ""1"",
            ""Date"": ""2023-11-10"",
            ""City"": ""Varik"",
            ""Address"": ""De Geus bv"",
            ""TimeArrive"": ""17:00 PM"",
            ""TimeDepart"": ""18:00 PM"",
            ""TypeOf"": ""Pickup"",
            ""Status"": ""Not completed"",
        },
        {
            ""ID"": ""1"",
            ""Date"": ""2023-11-10"",
            ""City"": ""Tilburg"",
            ""Address"": ""Oaksoft"",
            ""TimeArrive"": ""17:00 PM"",
            ""TimeDepart"": ""18:00 PM"",
            ""TypeOf"": ""Delivery"",
            ""Status"": ""Not completed"",

        }
    ]";
            
            List<Destination> destinations = JsonConvert.DeserializeObject<List<Destination>>(jsonData);
            
            List<Destination> filteredDestinations = destinations.Where(d => d.ID == routeId).ToList();

            return filteredDestinations;
            
        }

        private void DisplayDestinations(int routeId)
        {
            List<Destination> routes = FetchRoutesForId(routeId);
            lblDestinations.ItemsSource = routes;
        }

        private void OnRouteTapped(object sender, EventArgs e)
        {
            var selectedRoute = ((sender as StackLayout)?.BindingContext as Destination);
            Navigation.PushAsync(new RouteDetails(selectedRoute));
        }
    }
}
