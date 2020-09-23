using DI.Lab.Interfaces.Final.Repositories;
using DI.Lab.Interfaces.Final.Services;
using DI.Lab.Services.Final.Repositories;
using DI.Lab.Services.Final.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DI.Lab.Services.Final
{
    public static class LibraryConfiguration
    {
        public static IServiceCollection AddOrderLibServices(this IServiceCollection services)
        {
            services.AddSingleton<ICustomerProcessor, CustomerProcessor>();
            services.AddSingleton<INotifier, Notifier>();
            services.AddSingleton<IBillingProcessor, BillingProcessor>();
            services.AddSingleton<IOrderProcessor, OrderProcessor>();

            return services;
        }

        public static IServiceCollection AddOrderLibRepositories(this IServiceCollection services)
        {
            services.AddSingleton<ICustomerRepository, CustomerRepository>();
            services.AddSingleton<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
