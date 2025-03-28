using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TodoListApp.Applicationx.Extensions;
using TodoListApp.Applicationx.Queries.HelloWorldMessage;
using TodoListApp.Applicationx.Services.Abstractions;
using TodoListApp.Infrastructure.Abstractions;
using TodoListApp.Infrastructure.DataContext;
using TodoListApp.Infrastructure.Repositories;
using TodoListApp.Mobile.Services;
using TodoListApp.Mobile.ViewModels;
using TodoListApp.Mobile.Views;

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
            builder.Services.AddTransient<CategoriesViewModel>();
            builder.Services.AddTransient<CategoriesView>();

            builder.Services.AddTransient<EditCategoryViewModel>();
            builder.Services.AddTransient<EditCategoryPage>();

            builder.Services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(HelloWorldMessageQuery).Assembly));

            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

            builder.Services.AddApplicationServices();


            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "todoList.db");

            builder.Services.AddDbContext<TodoListDbContext>(options =>
            options.UseSqlite($"Filename={databasePath}"));


#if DEBUG
            builder.Logging.AddDebug();
#endif

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var dbcontext = scope.ServiceProvider.GetRequiredService<TodoListDbContext>();
                dbcontext.Database.Migrate();
            }

            return app;
        }
    }
}
