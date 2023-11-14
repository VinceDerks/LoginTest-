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
    private DateTime selectedDate;

    public static ContentPage RootPage { get; set; }

    public RouteDirections()
    {
        InitializeComponent();
        currentDate = DateTime.Today;
        selectedDate = currentDate;
        UpdateRoutes();
        DisplayRoutes(currentDate);

        RootPage = this;
    }

    private void UpdateRoutes()
    {

        var routes = FetchRouteForDate(currentDate);
        lblRoutes.ItemsSource = routes;
    }

    private List<Route> FetchRouteForDate(DateTime date)
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

    private void OnRouteTapped(object sender, EventArgs e)
    {
        Navigation.PushAsync(new RoutePage(selectedRoute));
    }

}
