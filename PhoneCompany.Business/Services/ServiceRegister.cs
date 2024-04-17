using Microsoft.Extensions.DependencyInjection;
using PhoneCompany.Common.Interfaces;

namespace PhoneCompany.Business.Services
{
    public static class ServiceRegister
    {
        public static IServiceCollection AddServices(this IServiceCollection services) => services
           .AddSingleton<IAbonentService, AbonentService>()
            ;

    }
}
