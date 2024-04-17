using Microsoft.Extensions.DependencyInjection;

namespace PhoneCompany.UI.ViewModels
{
    internal static class ViewModelsRegister
    {
        public static IServiceCollection AddViews(this IServiceCollection services) => services
            .AddSingleton<MainWindowViewModel>()
            .AddSingleton<FindWindowViewModel>()
            .AddSingleton<StreetWindowsViewModel>()
            
        ;
    }
}
