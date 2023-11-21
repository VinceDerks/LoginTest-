using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;
using Newtonsoft.Json;
using System.IO;
using LoginTest.Model;
using System.Linq;
using CommunityToolkit.Mvvm.Input;

namespace LoginTest
{
    public partial class NotArrivedPage : ContentPage
    {
        private Destination SelectedRoute;
        private const int CAMERA_PERMISSION_REQUEST_CODE = 100;
        private FileResult photo;
        public NotArrivedPage(Destination destination)
        {
            InitializeComponent();
            SelectedRoute = destination;
            BindingContext = this;

        }

        private async void RequestCameraPermission()
        {
            var status = await Permissions.CheckStatusAsync<Permissions.Camera>();

            if (status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<Permissions.Camera>();
            }

            if (status == PermissionStatus.Granted)
            {
                // Camera permission has been granted
                // Proceed with using the camera
            }
            else
            {
                // Camera permission has been denied
                // Handle the lack of camera access
            }
        }


        private async void SaveButtonClicked(object sender, EventArgs e)
        {
            if (photo != null)
            {
                SelectedRoute.Image = await ConvertToByteArray(photo);
            }

            if (!string.IsNullOrEmpty(RemarkField.Text))
            {
                SelectedRoute.Remark = RemarkField.Text;
            }

            await Navigation.PopAsync();
            await Navigation.PopAsync();
        }

        private async void CancelButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
            await Navigation.PopAsync();
        }
        private async void TakePictureClicked(object sender, EventArgs e)
        {
            RequestCameraPermission();
            photo = await MediaPicker.CapturePhotoAsync();

            OnPropertyChanged(nameof(PhotoSource)); // Notify the UI about the change
            OnPropertyChanged(nameof(HasPhoto));
        }

        private async void AttachPictureClicked(object sender, EventArgs e)
        {
            RequestCameraPermission();
            photo = await MediaPicker.PickPhotoAsync();

            OnPropertyChanged(nameof(PhotoSource)); // Notify the UI about the change
            OnPropertyChanged(nameof(HasPhoto));
        }

        private async Task<byte[]> ConvertToByteArray(FileResult fileResult)
        {
            using (var stream = await fileResult.OpenReadAsync())
            using (var memoryStream = new MemoryStream())
            {
                await stream.CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }
        }
        public ImageSource PhotoSource => photo?.FullPath;

        public bool HasPhoto => photo != null;

        private void RemovePhotoButtonClicked(object sender, EventArgs e)
        {
            photo = null; // Clear the photo variable
            OnPropertyChanged(nameof(PhotoSource)); // Notify the UI about the change
            OnPropertyChanged(nameof(HasPhoto)); // Notify the UI about the change
        }
    }
}