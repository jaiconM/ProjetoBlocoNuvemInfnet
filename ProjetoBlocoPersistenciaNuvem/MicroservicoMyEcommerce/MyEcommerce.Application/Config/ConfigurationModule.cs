using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MyEcommerce.Application.Service;

namespace MyEcommerce.Application.Config;

public static class ConfigurationModule
{
    public static IServiceCollection RegisterApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ConfigurationModule).Assembly);

        services.AddMediatR(typeof(ConfigurationModule).Assembly);

        services.AddScoped<IProdutoService, ProdutoService>();
        services.AddScoped<IClienteService, ClienteService>();
        services.AddScoped<IVendaService, VendaService>();


        return services;
    }
}
