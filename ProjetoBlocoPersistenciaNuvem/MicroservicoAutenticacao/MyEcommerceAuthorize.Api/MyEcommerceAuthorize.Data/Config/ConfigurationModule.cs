using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyEcommerceAuthorize.Data.Contexto;
using MyEcommerceAuthorize.Data.Database;
using MyEcommerceAuthorize.Data.Repository;
using MyEcommerceAuthorize.Domain.ContaContext.Repository;

namespace MyEcommerceAuthorize.Data.Config;

public static class ConfigurationModule
{
    public static IServiceCollection RegisterRepository(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<MyEcommerceAuthorizeContext>(c => c.UseSqlServer(connectionString));

        services.AddScoped(typeof(Repository<>));
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();

        return services;
    }
}
