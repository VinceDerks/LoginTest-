using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;
using Newtonsoft.Json;
using System.IO;
using LoginTest.Model;
using Microsoft.VisualBasic;
using System.Windows.Input;
namespace LoginTest;

public partial class RouteDirections : ContentPage
{
    private DateTime currentDate;
    public RouteDirections()
    {
        InitializeComponent();
        UpdateRoutes();
        DisplayRoutes(currentDate);
    }
    private void UpdateRoutes()
    {
        var routes = FetchRoutesForDate(currentDate);
        lblRoutes.ItemsSource = routes;
    }

    private List<Route> FetchRoutesForDate(DateTime date)
    {
        string jsonData = @"[
                        {
                            ""Name"": ""DENBOSCH"",
                            ""ID"": ""1"",
                            ""Date"": ""14-11-2023"",
                            ""TimeStart"": ""10:00 AM"",
                            ""TimeEnd"": ""1:00 PM""
                          }
                        ]";

        List<Route> routes = JsonConvert.DeserializeObject<List<Route>>(jsonData);

        List<Route> filteredRoutes = routes.FindAll(r => r.Date.Date == date.Date);

        return filteredRoutes;
    }
    private void DisplayRoutes(DateTime date)
    {
        List<Route> routes = FetchRoutesForDate(date);
        lblRoutes.ItemsSource = routes;
    }

    private void OnRouteTapped(object sender, EventArgs e)
    {
        var selectedRoute = ((sender as StackLayout)?.BindingContext as Route);
        Navigation.PushAsync(new RoutesPage(selectedRoute.ID));
    }



}
