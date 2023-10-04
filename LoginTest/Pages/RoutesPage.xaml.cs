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
           
            selectedDate = selectedDate.AddDays(-1);
            DateTime previousDay = selectedDate;
            
            DisplayRoutes(previousDay);
        }

        private void OnNextClicked(object sender, EventArgs e)
        {
            
           selectedDate = selectedDate.AddDays(1);
            DateTime nextDay = selectedDate;
            DisplayRoutes(nextDay);
        }
        private void UpdateRoutes()
        {
           
            var routes = FetchRoutesForDate(currentDate);
            lblRoutes.ItemsSource = routes;
        }

        private List<RoutesSrc> FetchRoutesForDate(DateTime date)
        {
            string jsonData = @"[
                          {
                            ""ID"": ""1"",
                            ""Date"": ""2023-09-26"",
                            ""City"": ""Tilburg"",
                            ""Adress"": ""Distelweg 52"",
                            ""TimeArrive"": ""10:00 PM"",
                            ""TimeDepart"": ""18:00 PM"",
                            ""TypeOf"": ""Delivery""
                          },
                          {
                            ""ID"": 2,
                            ""Date"": ""2023-09-26"",
                            ""City"": ""Varik"",
                            ""Adress"": ""De Geus bv"",
                            ""TimeArrive"": ""17:00 PM"",
                            ""TimeDepart"": ""18:00 PM"",
                            ""TypeOf"": ""Pickup""
                          },
                          {
                            ""ID"": 3,
                            ""Date"": ""2023-09-26"",
                            ""City"": ""Tilburg"",
                            ""Adress"": ""Oaksoft"",
                            ""TimeArrive"": ""17:00 PM"",
                            ""TimeDepart"": ""18:00 PM"",
                            ""TypeOf"": ""Delivery""
                          }
                        ]";

            List<RoutesSrc> routes = JsonConvert.DeserializeObject<List<RoutesSrc>>(jsonData);

            List<RoutesSrc> filteredRoutes = routes.FindAll(r => r.Date.Date == date.Date);

            return filteredRoutes;
        }

        private void DisplayRoutes(DateTime date)
        {

            List<RoutesSrc> routes = FetchRoutesForDate(date);

           
            lblRoutes.ItemsSource = routes;
            CurrentDate.Text = selectedDate.ToString();
        }


        private void OnRouteTapped(object sender, EventArgs e)
        {
            var selectedRoute = ((sender as StackLayout)?.BindingContext as RoutesSrc);
            Navigation.PushAsync(new RouteDetails(selectedRoute));
        }
    }

}

