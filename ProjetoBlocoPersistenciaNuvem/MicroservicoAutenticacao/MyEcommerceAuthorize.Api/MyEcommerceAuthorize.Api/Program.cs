using MyEcommerceAuthorize.Api.Config;
using MyEcommerceAuthorize.Application.Config;
using MyEcommerceAuthorize.Data.Config;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureAutenticacao(builder);

builder.Services.AddControllers();
builder.Services
    .RegisterApplication()
    .RegisterRepository(builder.Configuration["MyEcommerceDBConn"]);

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
