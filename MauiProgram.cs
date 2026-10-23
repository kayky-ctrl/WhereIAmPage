using Microsoft.Extensions.Logging;
using WhereIAmPage.Services;
using WhereIAmPage.ViewModels;
using WhereIAmPage.Views;

namespace WhereIAmPage
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddTransient<LocationViewModel>();
            builder.Services.AddTransient<LocationPage>();
            builder.Services.AddSingleton<IGeoService, GeoService>();

            return builder.Build();
        }
    }
}
