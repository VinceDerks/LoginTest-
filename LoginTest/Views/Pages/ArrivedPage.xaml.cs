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
        private Destination selectedRoute;

        public ArrivedPage(Destination selectedRoute)
        {
            InitializeComponent();
            this.selectedRoute = selectedRoute;
        }


        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            if (SignatureEntry.Lines != null)
            {
                var stream2 = await SignatureEntry.GetImageStream(200, 200);

                if (stream2 != null)
                {
                    byte[] bytes = new byte[stream2.Length];
                    stream2.Read(bytes, 0, bytes.Length);
                    selectedRoute.Image = bytes;
                    errorlbl.Text = "Handtekening opgeslagen";
                    selectedRoute.Status = "Completed";
                    selectedRoute.Remark = RemarkField.Text;
                    
                    await Navigation.PopAsync();
                    await Navigation.PopAsync();
                    

                }
                else
                {
                    errorlbl.Text = "Het veld is leeg";
                    selectedRoute.Image = null;
                }
            }
            else
            {
                selectedRoute.Image = null;
            }
        }

        [Obsolete]
        private void ClearButton_Clicked(object sender, EventArgs e)
        {
            errorlbl.Text = "Handtekening gewist";
            SignatureEntry.Clear();
            SaveButton.IsVisible = false;
            ClearButton.IsVisible = false;
        }

        private void DrawingLineCompleted(object sender, DrawingLineCompletedEventArgs e)
        {
            errorlbl.Text = "";
            SaveButton.IsVisible = true;
            ClearButton.IsVisible = true;
        }
    }
}
