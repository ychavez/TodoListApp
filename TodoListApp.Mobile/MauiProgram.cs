using Microsoft.Extensions.Logging;
using TodoListApp.Applicationx.Services.Abstractions;
using TodoListApp.Mobile.Services;

namespace TodoListApp.Mobile
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
           
            builder.Services.AddScoped<INavigationService, NavigationService>();
            builder.Services.AddTransient<HelloWorldPage>();
            builder.Services.AddTransient<MainPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
