using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;
using Newtonsoft.Json;
using System.IO;
using LoginTest.Model;
using Microsoft.VisualBasic;
using System.Windows.Input;

namespace LoginTest
{
    public partial class RoutesPage : ContentPage
    {
        private DateTime currentDate;
        private DateTime selectedDate;

        public static ContentPage RootPage { get; set; }

        public RoutesPage()
        {
            InitializeComponent();
            currentDate = DateTime.Today;
            selectedDate = currentDate;
            UpdateRoutes();
            DisplayRoutes(currentDate);

            CurrentDate.DateSelected += DatePicker_DateSelected;

            RootPage = this; 
        }

        private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            selectedDate = e.NewDate;
            DisplayRoutes(selectedDate);
        }

        private void OnPreviousClicked(object sender, EventArgs e)
        {
            selectedDate = selectedDate.AddDays(-1);
            DisplayRoutes(selectedDate);
        }

        private void OnNextClicked(object sender, EventArgs e)
        {
            selectedDate = selectedDate.AddDays(1);
            DisplayRoutes(selectedDate);
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
                            ""TypeOf"": ""Delivery"",
                            ""Status"": ""Not completed""
                          },

                          {
                            ""ID"": 2,
                            ""Date"": ""2023-09-26"",
                            ""City"": ""Varik"",
                            ""Adress"": ""De Geus bv"",
                            ""TimeArrive"": ""17:00 PM"",
                            ""TimeDepart"": ""18:00 PM"",
                            ""TypeOf"": ""Pickup"",
                            ""Status"": ""Not completed""
                          },

                          {
                            ""ID"": 3,
                            ""Date"": ""2023-09-26"",
                            ""City"": ""Tilburg"",
                            ""Adress"": ""Oaksoft"",
                            ""TimeArrive"": ""17:00 PM"",
                            ""TimeDepart"": ""18:00 PM"",
                            ""TypeOf"": ""Delivery"",
                            ""Status"": ""Not completed""
                          },

                          {
                            ""ID"": 4,
                            ""Date"": ""2023-10-11"",
                            ""City"": ""Tilburg"",
                            ""Adress"": ""Distelweg 52"",
                            ""TimeArrive"": ""10:00 PM"",
                            ""TimeDepart"": ""18:00 PM"",
                            ""TypeOf"": ""Delivery"",
                            ""Status"": ""Not completed""
                          },

                          {
                            ""ID"": 5,
                            ""Date"": ""2023-10-11"",
                            ""City"": ""Varik"",
                            ""Adress"": ""De Geus bv"",
                            ""TimeArrive"": ""17:00 PM"",
                            ""TimeDepart"": ""18:00 PM"",
                            ""TypeOf"": ""Pickup"",
                            ""Status"": ""Not completed""
                          },

                          {
                            ""ID"": 6,
                            ""Date"": ""2023-10-11"",
                            ""City"": ""Tilburg"",
                            ""Adress"": ""Oaksoft"",
                            ""TimeArrive"": ""17:00 PM"",
                            ""TimeDepart"": ""18:00 PM"",
                            ""TypeOf"": ""Delivery"",
                            ""Status"": ""Not completed""
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

            CurrentDate.Date = selectedDate;
        }


        private void OnRouteTapped(object sender, EventArgs e)
        {
            var selectedRoute = ((sender as StackLayout)?.BindingContext as RoutesSrc);
            Navigation.PushAsync(new RouteDetails(selectedRoute));
        } 
        
    }

}

