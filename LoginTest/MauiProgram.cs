using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using InputKit.Shared.Controls;
using Mopups.Hosting;
using UraniumUI;

namespace LoginTest
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiCommunityToolkit()
                .UseMauiApp<App>()
                .ConfigureMopups()
                .UseUraniumUI()
                .UseUraniumUIMaterial()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");

                    fonts.AddMaterialIconFonts();
                });


            builder.Services.AddMopupsDialogs();
            return builder.Build();
        }
    }
}