using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MyEcommerceAuthorize.Application.ContaContext.Service;

namespace MyEcommerceAuthorize.Application.Config;

public static class ConfigurationModule
{
    public static IServiceCollection RegisterApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ConfigurationModule).Assembly);
        services.AddMediatR(typeof(ConfigurationModule).Assembly);

        services.AddScoped<IUsuarioService, UsuarioService>();

        return services;
    }
}
