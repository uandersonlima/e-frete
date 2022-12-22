using efrete.Addresses.Application.Queries;
using efrete.Addresses.Data;
using efrete.Addresses.Data.Repository;
using efrete.Addresses.Domain;

namespace efrete.WebApp.MVC.Setup
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection service, ConfigurationManager conf)
        {
            var contextSettings = conf.GetValue<string>("BD:path") ?? string.Empty;
            service.AddScoped<AddressContext>(sp => new AddressContext(contextSettings));
            service.AddScoped<IAddressQueries, AddressQueries>();
            service.AddScoped<IAddressRepository, AddressRepository>();
        }
    }
}