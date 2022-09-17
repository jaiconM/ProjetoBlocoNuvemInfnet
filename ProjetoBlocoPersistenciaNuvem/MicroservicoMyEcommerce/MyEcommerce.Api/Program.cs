using MyEcommerce.Api.Config;
using MyEcommerce.Api.Filters;
using MyEcommerce.Application.Config;
using MyEcommerce.Data.Config;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureAutenticacao(builder);

builder.Services.AddControllers(options =>
{
    options.Filters.Add<CustomExceptionFilterAtribute>();
});

builder.Services.RegisterApplication();

builder.Services.RegisterRepository(builder.Configuration.GetConnectionString("MyEcommerceDataDBConn"));

builder.Services.AddEndpointsApiExplorer();

builder.Services.ConfigureSwagger();

WebApplication app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
