using Microsoft.Maui.Controls;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Maui.Core;
using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using CommunityToolkit.Maui.Core.Views;
using LoginTest.Model;
namespace LoginTest
{
    public partial class ArrivedPage : ContentPage
    {
        private RoutesSrc selectedRoute;

        public ArrivedPage(RoutesSrc selectedRoute)
        {
            InitializeComponent();
            this.selectedRoute = selectedRoute;
        }


        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            var stream2 = await SignatureEntry.GetImageStream(200, 200);

            byte[] bytes = new byte[stream2.Length];
            stream2.Read(bytes, 0, bytes.Length);
            
            selectedRoute.Image = bytes;
        }

        [Obsolete]
        private async void DrawingView_DrawingLineCompleted(object sender, CommunityToolkit.Maui.Core.DrawingLineCompletedEventArgs e)
        {
            var stream = await SignatureEntry.GetImageStream(200,200);
            Device.BeginInvokeOnMainThread(() => {
                Signature.Source = ImageSource.FromStream(() => stream);
            });
        }

        private void ClearButton_Clicked(object sender, EventArgs e)
        {
            SignatureEntry.Clear();
            Signature.Source = null;
        }

    }
}
