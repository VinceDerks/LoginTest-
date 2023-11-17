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
        private Destination SelectedRoute;
        private List<OrderItem> Products;
        
        public ItemsPage(Destination destination)
        {
            InitializeComponent();
            SelectedRoute = destination;
            BindingContext = this;
            Products = SelectedRoute.Products;
            DisplayOrders();
            lblOrder.ItemsSource = SelectedRoute.Order;
        }

        private void DisplayOrders()
        {            
            if (Products != null && Products.Count > 0)
            {                
                lblOrders.ItemsSource = Products;               
                Errorlbl.IsVisible = false; // Clear the error message
            }
            else
            {
                lblOrders.ItemsSource = null; // Clear the items source
                Errorlbl.IsVisible = true;
                Errorlbl.Text = "No orders found"; // Display the error message
            }
        }

        private void NavigateToArrivedPage(object sender, EventArgs e)
        {          
            Navigation.PushAsync(new ArrivedPage(SelectedRoute));
        }

        private void NavigateToNotArrivedPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NotArrivedPage(SelectedRoute));
        }

    }
}
