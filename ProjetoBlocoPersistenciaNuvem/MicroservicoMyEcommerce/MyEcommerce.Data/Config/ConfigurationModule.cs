using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyEcommerce.Data.AzureBlobStorageHelper;
using MyEcommerce.Data.Contexto;
using MyEcommerce.Data.Database;
using MyEcommerce.Data.Repository;
using MyEcommerce.Domain.Repository;

namespace MyEcommerce.Data.Config;

public static class ConfigurationModule
{
    public static IServiceCollection RegisterRepository(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<MyEcommerceContext>(c => c.UseSqlServer(connectionString));

        services.AddScoped(typeof(Repository<>));
        services.AddScoped<IClienteRepository, ClienteRepository>();
        services.AddScoped<IVendaRepository, VendaRepository>();
        services.AddScoped<IItemVendaRepository, ItemVendaRepository>();
        services.AddScoped<IAzureBlobStorage, AzureBlobStorage>();

        return services;
    }
}
