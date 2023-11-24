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
    public RouteDirections()
    {
        InitializeComponent();
        currentDate = DateTime.Today;
        selectedDate = currentDate;
        UpdateRoutes();        
        DisplayRoutes(currentDate);

        CurrentDate.DateSelected += DatePicker_DateSelected;
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
    private List<Route> FetchRoutesForDate(DateTime date)
    { 
        var settings = new JsonSerializerSettings
        {
            DateFormatString = "dd-MM-yyyy" 
        };
        string jsonData = @"[
                        {
                            ""Name"": ""Den Bosch"",
                            ""ID"": ""2"",
                            ""Date"": ""2023-11-21"",
                            ""TimeStart"": ""10:00"",
                            ""TimeEnd"": ""13:00"",
                            ""LadingGewicht"": ""45"",
                            ""LadingVolume"": ""4""
                          }, 
                        {
                            ""Name"": ""Den Bosch"",
                            ""ID"": ""1"",
                            ""Date"": ""2023-11-22"",
                            ""TimeStart"": ""10:00"",
                            ""TimeEnd"": ""13:00"",
                            ""LadingGewicht"": ""45"",
                            ""LadingVolume"": ""4""
                          },
                          {
                            ""Name"": ""Den Bosch"",
                            ""ID"": ""3"",
                            ""Date"": ""2023-11-20"",
                            ""TimeStart"": ""10:00"",
                            ""TimeEnd"": ""13:00"",
                            ""LadingGewicht"": ""45"",
                            ""LadingVolume"": ""4""
                          }, 
                         {
                            ""Name"": ""Den Bosch"",
                            ""ID"": ""4"",
                            ""Date"": ""2023-11-21"",
                            ""TimeStart"": ""10:00"",
                            ""TimeEnd"": ""13:00"",
                            ""LadingGewicht"": ""45"",
                            ""LadingVolume"": ""4""
                          }, 
                        {
                            ""Name"": ""Den Bosch"",
                            ""ID"": ""5"",
                            ""Date"": ""2023-11-22"",
                            ""TimeStart"": ""10:00"",
                            ""TimeEnd"": ""13:00"",
                            ""LadingGewicht"": ""45"",
                            ""LadingVolume"": ""4""
                          },
                          {
                            ""Name"": ""Den Bosch"",
                            ""ID"": ""6"",
                            ""Date"": ""2023-11-20"",
                            ""TimeStart"": ""10:00"",
                            ""TimeEnd"": ""13:00"",
                            ""LadingGewicht"": ""45"",
                            ""LadingVolume"": ""4""
                          },
                          {
                            ""Name"": ""Den Bosch"",
                            ""ID"": ""2"",
                            ""Date"": ""2023-11-21"",
                            ""TimeStart"": ""13:00"",
                            ""TimeEnd"": ""15:00"",
                            ""LadingGewicht"": ""45"",
                            ""LadingVolume"": ""4""
                          }, 
                        {
                            ""Name"": ""Den Bosch"",
                            ""ID"": ""1"",
                            ""Date"": ""2023-11-22"",
                            ""TimeStart"": ""13:00"",
                            ""TimeEnd"": ""15:00 PM"",
                            ""LadingGewicht"": ""45"",
                            ""LadingVolume"": ""4""
                          },
                          {
                            ""Name"": ""Den Bosch"",
                            ""ID"": ""3"",
                            ""Date"": ""2023-11-20"",
                            ""TimeStart"": ""13:00"",
                            ""TimeEnd"": ""15:00"",
                            ""LadingGewicht"": ""45"",
                            ""LadingVolume"": ""4""
                          }, 
                         {
                            ""Name"": ""Den Bosch"",
                            ""ID"": ""4"",
                            ""Date"": ""2023-11-21"",
                            ""TimeStart"": ""13:00"",
                            ""TimeEnd"": ""15:00"",
                            ""LadingGewicht"": ""45"",
                            ""LadingVolume"": ""4""
                          }, 
                        {
                            ""Name"": ""Den Bosch"",
                            ""ID"": ""5"",
                            ""Date"": ""2023-11-22"",
                            ""TimeStart"": ""13:00"",
                            ""TimeEnd"": ""15:00"",
                            ""LadingGewicht"": ""45"",
                            ""LadingVolume"": ""4""
                          },
                          {
                            ""Name"": ""Den Bosch"",
                            ""ID"": ""6"",
                            ""Date"": ""2023-11-20"",
                            ""TimeStart"": ""13:00"",
                            ""TimeEnd"": ""15:00"",
                            ""LadingGewicht"": ""45"",
                            ""LadingVolume"": ""4""
                          }, 

                            {
                            ""Name"": ""Den Bosch"",
                            ""ID"": ""4"",
                            ""Date"": ""2023-11-21"",
                            ""TimeStart"": ""13:00"",
                            ""TimeEnd"": ""15:00"",
                            ""LadingGewicht"": ""45"",
                            ""LadingVolume"": ""4""
                          }, 
                        ]";
        List<Route> routes = JsonConvert.DeserializeObject<List<Route>>(jsonData);

        List<Route> filteredRoutes = routes.FindAll(r => r.Date.Date == date.Date);

        return filteredRoutes;
    }
    private void DisplayRoutes(DateTime date)
    {
        List<Route> routes = FetchRoutesForDate(date);
        if (routes.Count > 0)
        {
            lblRoutes.ItemsSource = routes;
            Errorlbl.IsVisible=false; // Clear the error message
        }
        else
        {
            lblRoutes.ItemsSource = null; // Clear the items source
            Errorlbl.IsVisible = true;// Display the error message
        }

        CurrentDate.Date = selectedDate;
    }

    private void OnRouteTapped(object sender, EventArgs e)
    {
        var selectedRoute = ((sender as StackLayout)?.BindingContext as Route);
        Navigation.PushAsync(new RoutesPage(selectedRoute.ID));
    }
}
