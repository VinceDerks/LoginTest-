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
	public RouteDirections()
	{
		InitializeComponent();
	}

    private void OnRouteTapped(object sender, EventArgs e)
    {
        var selectedRoute = ((sender as StackLayout)?.BindingContext as RoutesSrc);
        Navigation.PushAsync(new RouteDetails(selectedRoute));
    }
}