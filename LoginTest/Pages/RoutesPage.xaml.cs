using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;
using Newtonsoft.Json;
using System.IO;
using LoginTest.Model;

namespace LoginTest
{
    public partial class RoutesPage : ContentPage
    {
        private DateTime currentDate;
        private DateTime selectedDate;

        public RoutesPage()
        {
            InitializeComponent();
            currentDate = DateTime.Today;
            selectedDate = currentDate;
            UpdateRoutes();
            DisplayRoutes(currentDate);
        }

        private void OnPreviousClicked(object sender, EventArgs e)
        {
            // Call DisplayRoutes with the desired date
            // Example: Display routes for the previous day
            selectedDate = selectedDate.AddDays(-1);
            DateTime previousDay = selectedDate;
            
            DisplayRoutes(previousDay);
        }

        private void OnNextClicked(object sender, EventArgs e)
        {
            // Call DisplayRoutes with the desired date
            // Example: Display routes for the next day
           selectedDate = selectedDate.AddDays(1);
            DateTime nextDay = selectedDate;
            DisplayRoutes(nextDay);
        }
        private void UpdateRoutes()
        {
            // Fetch the routes for the current date from your data source
            var routes = FetchRoutesForDate(currentDate);

            // Update the collection view with the new routes
            lblRoutes.ItemsSource = routes;
        }

        private List<RoutesSrc> FetchRoutesForDate(DateTime date)
        {
            string jsonData = @"[
                          {
                            ""Id"": 1,
                            ""Date"": ""2023-09-26"",
                            ""City"": ""Tilburg"",
                            ""Adress"": ""Distelweg 52"",
                            ""TimeArrive"": ""17:00 PM"",
                            ""TimeDepart"": ""18:00 PM"",
                            ""TypeOf"": ""Delivery""
                          },
                          {
                            ""Id"": 2,
                            ""Date"": ""2023-09-26"",
                            ""City"": ""Tilburg"",
                            ""Adress"": ""Rentbuddy bv"",
                            ""TimeArrive"": ""17:00 PM"",
                            ""TimeDepart"": ""18:00 PM"",
                            ""TypeOf"": ""Pickup""
                          },
                          {
                            ""Id"": 3,
                            ""Date"": ""2023-09-26"",
                            ""City"": ""Tilburg"",
                            ""Adress"": ""Oaksoft"",
                            ""TimeArrive"": ""17:00 PM"",
                            ""TimeDepart"": ""18:00 PM"",
                            ""TypeOf"": ""Delivery""
                          }
                        ]";

            // Deserialize the JSON data into a list of RoutesSrc objects
            List<RoutesSrc> routes = JsonConvert.DeserializeObject<List<RoutesSrc>>(jsonData);

            // Filter the routes based on the provided date
            List<RoutesSrc> filteredRoutes = routes.FindAll(r => r.Date.Date == date.Date);

            return filteredRoutes;
        }

        private void DisplayRoutes(DateTime date)
        {
            // Fetch the routes for the provided date
            List<RoutesSrc> routes = FetchRoutesForDate(date);

            // Set the ItemsSource of the CollectionView to the fetched routes
            lblRoutes.ItemsSource = routes;
            CurrentDate.Text = selectedDate.ToString();
        }
    }
}