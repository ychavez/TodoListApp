using TodoListApp.Applicationx.Services.Abstractions;

namespace TodoListApp.Mobile.Services
{
    public class NavigationService : INavigationService
    {
        private readonly IServiceProvider serviceProvider;

        public NavigationService(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public async Task NavigateToAsync(Type pageType)
        {
            if (!typeof(Page).IsAssignableFrom(pageType))
                throw new ArgumentException("El tipo deve der una pagina de MAUI");

            var page = serviceProvider.GetService(pageType) as Page;
            if (page is not null)
            {
                await Shell.Current.Navigation.PushAsync(page);
            }
        }

        public async Task GoBackAsync()
        {
            await Shell.Current.Navigation.PopAsync();
        }

    }
}
