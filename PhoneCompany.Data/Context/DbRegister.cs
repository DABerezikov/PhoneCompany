using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhoneCompany.Data.Repositories;

namespace PhoneCompany.Data.Context
{
    public static class DbRegister
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration) => services
            
            .AddSingleton(new DbInitializer(configuration.GetConnectionString("SQlite")))
            .AddRepositoriesInDb()
        ;
    }
}
