using Microsoft.Extensions.DependencyInjection;
using PhoneCompany.Common.Interfaces;
using PhoneCompany.Data.Entities;

namespace PhoneCompany.Data.Repositories
{
    public static class RepositoryRegister
    {
        public static IServiceCollection AddRepositoriesInDb(this IServiceCollection services) => services
            .AddScoped<IRepository<Street>,StreetRepository>()
        ;
    }
}
