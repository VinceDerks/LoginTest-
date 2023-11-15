using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;
using Newtonsoft.Json;
using System.IO;
using LoginTest.Model;
using System.Linq;

namespace LoginTest
{
    public partial class ItemsPage : ContentPage
    {
        private Destination selectedDestination;

        public ItemsPage(Destination destination)
        {
            InitializeComponent();
            selectedDestination = destination;

            DisplayOrders(selectedDestination.Orders);
        }

        private void DisplayOrders(List<Order> orders)
        {
            if (orders != null && orders.Count > 0)
            {
                lblOrders.ItemsSource = orders;
            }
            else
            {
                Errorlbl.Text = "No orders found";
            }
        }
    }
}
