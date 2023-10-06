using Microsoft.Maui.Controls;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Maui.Core;
using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using CommunityToolkit.Maui.Core.Views;

namespace LoginTest
{
    public partial class ArrivedPage : ContentPage
    {


        public ArrivedPage()
        {
            InitializeComponent();
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
