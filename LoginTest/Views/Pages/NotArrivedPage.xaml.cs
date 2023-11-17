using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;
using Newtonsoft.Json;
using System.IO;
using LoginTest.Model;
using System.Linq;
namespace LoginTest
{
    public partial class NotArrivedPage : ContentPage
    {
        private Destination SelectedRoute;

        public NotArrivedPage(Destination destination)
        {
            InitializeComponent();
            SelectedRoute = destination;
            BindingContext = this;
        }
    }
}