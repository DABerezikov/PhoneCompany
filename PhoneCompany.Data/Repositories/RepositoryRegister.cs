using Microsoft.Extensions.DependencyInjection;
using PhoneCompany.Data.Entities;
using PhoneCompany.Data.Repositories.Interfaces;

namespace PhoneCompany.Data.Repositories
{
    public static class RepositoryRegister
    {
        public static IServiceCollection AddRepositoriesInDb(this IServiceCollection services) => services
            .AddScoped<IRepository<Street>,StreetRepository>()
            .AddScoped<IRepository<Abonent>, AbonentRepository>()
        ;
    }
}
