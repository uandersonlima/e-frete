using efrete.Addresses.Application.Queries;
using efrete.Addresses.Data;
using efrete.Addresses.Data.Repository;
using efrete.Addresses.Domain;
using efrete.Core.Communication;
using efrete.Core.Messages.Common.Notifications;
using MediatR;

namespace efrete.WebApp.MVC.Setup
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services, ConfigurationManager conf)
        {
            // Mediator
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            // Notifications
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            //Address
         
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IAddressQueries, AddressQueries>();
            services.AddScoped<IAddressRepository, AddressRepository>();

            var mainPath = conf.GetValue<string>("BD:mainPath") ?? string.Empty;
            var sCPath = conf.GetValue<string>("BD:sCPath") ?? string.Empty;
            services.AddScoped<AddressContext>(sp => new AddressContext(mainPath, sCPath));
        
        }
    }
}