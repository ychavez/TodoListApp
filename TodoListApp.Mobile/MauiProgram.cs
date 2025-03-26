using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TodoListApp.Applicationx.Queries.HelloWorldMessage;
using TodoListApp.Applicationx.Services.Abstractions;
using TodoListApp.Infrastructure.Abstractions;
using TodoListApp.Infrastructure.DataContext;
using TodoListApp.Infrastructure.Repositories;
using TodoListApp.Mobile.Services;
using TodoListApp.Mobile.ViewModels;

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
            builder.Services.AddTransient<HelloWorldViewModel>();
            
            builder.Services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(HelloWorldMessageQuery).Assembly));

            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

            builder.Services.AddDbContext<TodoListDbContext>(options => options.UseSqlite($"Filename=todo.db"));


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
