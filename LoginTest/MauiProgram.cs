using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Material.Components.Maui.Extensions;
using UraniumUI;

namespace LoginTest
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder
            .UseMaterialComponents(new List<string>
            {
                //generally, we needs add 6 types of font families
                "Roboto-Regular.ttf",
                "Roboto-Italic.ttf",
                "Roboto-Medium.ttf",
                "Roboto-MediumItalic.ttf",
                "Roboto-Bold.ttf",
                "Roboto-BoldItalic.ttf",
            })
            .UseUraniumUI()
            .UseUraniumUIMaterial();
            return builder.Build();


        }
    }
}