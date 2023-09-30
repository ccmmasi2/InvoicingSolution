using Invoicing.AccessData.Data;
using Invoicing.AccessData.ObjectRepository.Interface;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Invoicing.Core.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddContext(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>();
            services.AddScoped<ILogger, Logger<AppDbContext>>();
            return services;
        }

        /// <summary>
        /// Adds the dependency injection.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns>IServiceCollection.</returns>
        /// <remarks>Priscy Antonio Reales</remarks>
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IInvoiceDtlRepository, InvoiceDtlRepository>();
            services.AddScoped<IInvoiceHdrRepository, InvoiceHdrRepository>();
            services.AddScoped<IProductPriceRepository, ProductPriceRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IStoreRepository, StoreRepository>();

            return services;
        }
    }
}
