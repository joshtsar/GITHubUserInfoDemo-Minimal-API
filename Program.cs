using Carter;

using Microsoft.AspNetCore.Mvc.ApiExplorer;

using MinimalAPIDemoByJiahuaTong.Middleware;
using MinimalAPIDemoByJiahuaTong.Services;

using MinimapAPIDemoByJiahuaTong.Query;
using MinimapAPIDemoByJiahuaTong.Services.Helper;

using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
IConfiguration config = new ConfigurationBuilder()
            //.SetBasePath(Directory.GetCurrentDirectory())
            //.AddEnvironmentVariables()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();

Log.Logger = new LoggerConfiguration()
       .ReadFrom.Configuration(config)
      .CreateLogger();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetUsersQuery).Assembly));

builder.Services.AddLogging(configure => configure.AddSerilog());

builder.Services.AddSingleton(config);
builder.Services.AddScoped<IGHPublicApi, GHPublicAPIService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

//builder.Services.AddApiVersioningConfigured();
//builder.Services.AddSwaggerSwashbuckleConfigured();

builder.Services.AddSwaggerGen();
builder.Services.ConfigureSwaggerGen(setup =>
{
    setup.EnableAnnotations();
    setup.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Github Public API-Get User Info Demo-Minimal API",
        Version = "v1",
        Description = "A Demo Minimla API Project using MediatR to get Github users basic Info.",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Jiahua Tong(Joshua Tong)",
            Email = "up432014@hotmail.com"
        }
    });
});

builder.Services.AddHttpClient();

builder.Services.AddCarter();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI();
    // Enable middleware to serve Swagger-UI (HTML, JS, CSS, etc.) by specifying the Swagger JSON endpoint(s).
    //var descriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
    //app.UseSwaggerUI(options =>
    //{
    //    // Build a swagger endpoint for each discovered API version
    //    foreach (var description in descriptionProvider.ApiVersionDescriptions)
    //    {
    //        options.SwaggerEndpoint($"{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
    //    }
    //});

}

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapCarter();

app.Run();
