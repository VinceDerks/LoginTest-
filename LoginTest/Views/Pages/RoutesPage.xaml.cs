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
            ""CompanyName"": ""RentBuddy"",
            ""Contact"": ""Janssen"",
            ""ContactPhone"": ""06128816192"",
            ""Adress"": ""Distelweg 52 5345KD Oss"",
            ""TimeArrive"": ""10:00 PM"",
            ""TimeDepart"": ""18:00 PM"",
            ""TypeOf"": ""Delivery"",
            ""Status"": ""Not completed"",
             ""orderid"": 258,
            ""Products"": [
                {
                    ""orderid"": 258,
                    ""ProductName"": ""Kabel"",
                    ""ProductCode"": 258258,
                    ""Quantity"": 5,
                    
                },
            ],
            ""Order"": [
                {
                    ""orderId"": 258,
                    ""ID"": 1
                },
            ]
        },
        {
            ""ID"": ""1"",
            ""Date"": ""2023-11-10"",
            ""CompanyName"": ""RentBuddy"",
            ""Contact"": ""Janssen"",
            ""ContactPhone"": ""06128816192"",
            ""City"": ""Varik"",
            ""Adress"": ""De Geus bv"",
            ""TimeArrive"": ""17:00 PM"",
            ""TimeDepart"": ""18:00 PM"",
            ""TypeOf"": ""Pickup"",
            ""Status"": ""Not completed"",
            ""orderid"": 259,
            ""Products"": [
                {
                    ""orderid"": 259,
                    ""ProductName"": ""Alien Onesie"",
                    ""ProductCode"": 6060606,
                    
                }],
            ""Order"": [
                {
                    ""orderid"": 259,
                    ""ID"": 1
                },
            ]
        },
        {
            ""ID"": ""1"",
            ""Date"": ""2023-11-10"",
            ""CompanyName"": ""RentBuddy"",
            ""Contact"": ""Janssen"",
            ""ContactPhone"": ""06128816192"",
            ""City"": ""Tilburg"",
            ""Adress"": ""Oaksoft"",
            ""TimeArrive"": ""17:00 PM"",
            ""TimeDepart"": ""18:00 PM"",
            ""TypeOf"": ""Delivery"",
            ""Status"": ""Not completed"",
           ""orderid"": 258,
             ""Products"": [
                {
                    ""orderid"": 258,
                    ""ProductName"": ""Kabel"",
                    ""ProductCode"": 258258,
                    
                }],
            ""Order"": [
                {
                    ""orderid"": 258,
                    ""ID"": 1
                },
            ]
        }
    ]";

            List<Destination> destinations = JsonConvert.DeserializeObject<List<Destination>>(jsonData);

            List<Destination> filteredDestinations = destinations.Where(d => d.ID == routeId).ToList();

            return filteredDestinations;
        }

        private void DisplayDestinations(int routeId)
        {
            List<Destination> routes = FetchRoutesForId(routeId);
            if(routes != null)
            { 
              lblDestinations.ItemsSource = routes;
            }
            else
            {
                Errorlbl.Text = "Geen afleverpunten gevonden";
            }
        }

        private void OnRouteTapped(object sender, EventArgs e)
        {
            var selectedDestination = ((sender as StackLayout)?.BindingContext as Destination);
            Navigation.PushAsync(new RouteDetails(selectedDestination)); 
        }
    }
}
