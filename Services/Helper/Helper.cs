//using MicroElements.Swashbuckle.FluentValidation.AspNetCore;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
//using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;

using System.Reflection;

namespace MinimapAPIDemoByJiahuaTong.Services.Helper
{
    public static class Helper
    {
        #region save for later debug 
        //ref. https://www.dotnetnakama.com/blog/enriched-web-api-documentation-using-swagger-openapi-in-asp-dotnet-core/
        /// <summary>
        /// Configure the Swagger generator with XML comments, bearer authentication, etc.
        /// Additional configuration files:
        /// <list type="bullet">
        ///     <item>ConfigureSwaggerSwashbuckleOptions.cs</item>
        /// </list>
        /// </summary>
        /// <param name="services"></param>
        //public static void AddSwaggerSwashbuckleConfigured(this IServiceCollection services)
        //{
        //    services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerSwashbuckleOptions>();

        //    // Configures ApiExplorer (needed from ASP.NET Core 6.0).
        //    services.AddEndpointsApiExplorer();

        //    // Register the Swagger generator, defining one or more Swagger documents.
        //    // Read more here: https://github.com/domaindrivendev/Swashbuckle.AspNetCore
        //    services.AddSwaggerGen(options =>
        //    {
        //        // If we would like to provide request and response examples (Part 1/2)
        //        // Enable the Automatic (or Manual) annotation of the [SwaggerRequestExample] and [SwaggerResponseExample].
        //        // Read more here: https://github.com/mattfrear/Swashbuckle.AspNetCore.Filters
        //        //options.ExampleFilters();

        //        // If we would like to include documentation comments in the OpenAPI definition file and SwaggerUI.
        //        // Set the comments path for the XmlComments file.
        //        // Read more here: https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-6.0&tabs=visual-studio#xml-comments
        //        string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        //        string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        //        options.IncludeXmlComments(xmlPath);

        //        // If we would like to provide security information about the authorization scheme that we are using (e.g. Bearer).
        //        // Add Security information to each operation for bearer tokens and define the scheme.
        //        //options.OperationFilter<SecurityRequirementsOperationFilter>(true, "Bearer");
        //        //options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        //        //{
        //        //    Description = "Standard Authorization header using the Bearer scheme (JWT). Example: \"bearer {token}\"",
        //        //    Name = "Authorization",
        //        //    In = ParameterLocation.Header,
        //        //    Type = SecuritySchemeType.ApiKey,
        //        //    Scheme = "Bearer"
        //        //});

        //        // If we use the [Authorize] attribute to specify which endpoints require Authorization, then we can
        //        // Show an "(Auth)" info to the summary so that we can easily see which endpoints require Authorization.
        //        //options.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
        //    });

        //    // If we would like to provide request and response examples (Part 2/2)
        //    // Register examples with the ServiceProvider based on the location assembly or example type.
        //    services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());

        //    // If we are using FluentValidation, then we can register the following service to add the  fluent validation rules to swagger.
        //    // Adds FluentValidationRules staff to Swagger. (Minimal configuration)
        //    //services.AddFluentValidationRulesToSwagger();
        //    //return services;
        //}

        //ref. https://www.dotnetnakama.com/blog/enriched-web-api-documentation-using-swagger-openapi-in-asp-dotnet-core/
        //public static IServiceCollection AddApiVersioningConfigured(this IServiceCollection services)
        //{
        //    services.AddApiVersioning(options =>
        //    {
        //        // ReportApiVersions will return the "api-supported-versions" and "api-deprecated-versions" headers.
        //        options.ReportApiVersions = true;

        //        // Set a default version when it's not provided,
        //        // e.g., for backward compatibility when applying versioning on existing APIs
        //        options.AssumeDefaultVersionWhenUnspecified = true;
        //        options.DefaultApiVersion = new ApiVersion(1, 0);

        //        // Combine (or not) API Versioning Mechanisms:
        //        options.ApiVersionReader = ApiVersionReader.Combine(
        //                // The Default versioning mechanism which reads the API version from the "api-version" Query String paramater.
        //                new QueryStringApiVersionReader("api-version"),
        //                // Use the following, if you would like to specify the version as a custom HTTP Header.
        //                new HeaderApiVersionReader("Accept-Version"),
        //                // Use the following, if you would like to specify the version as a Media Type Header.
        //                new MediaTypeApiVersionReader("api-version")
        //            );
        //    });

        //    // Support versioning on our documentation.
        //    services.AddVersionedApiExplorer(options =>
        //    {
        //        // Format the version as "v{Major}.{Minor}.{Patch}" (e.g. v1.0.0).
        //        options.GroupNameFormat = "'v'VVV";

        //        // Note: this option is only necessary when versioning by url segment. the SubstitutionFormat
        //        // can also be used to control the format of the API version in route templates
        //        options.SubstituteApiVersionInUrl = true;
        //    });

        //    return services;
        //}

        //ref. https://www.dotnetnakama.com/blog/enriched-web-api-documentation-using-swagger-openapi-in-asp-dotnet-core/
        /// <summary>
        /// Configures the Swagger generation options.
        /// </summary>
        /// <remarks>This allows API versioning to define a Swagger document per API version after the
        /// <see cref="IApiVersionDescriptionProvider"/> service has been resolved from the service container.</remarks>
        //public class ConfigureSwaggerSwashbuckleOptions
        //: IConfigureOptions<SwaggerGenOptions>
        //{
        //    readonly IApiVersionDescriptionProvider provider;

        //    /// <summary>
        //    /// Initializes a new instance of the <see cref="ConfigureSwaggerSwashbuckleOptions"/> class.
        //    /// </summary>
        //    /// <param name="provider">The <see cref="IApiVersionDescriptionProvider">provider</see> used to generate Swagger documents.</param>
        //    public ConfigureSwaggerSwashbuckleOptions(IApiVersionDescriptionProvider provider) => this.provider = provider;

        //    /// <inheritdoc />
        //    public void Configure(SwaggerGenOptions options)
        //    {
        //        // Add a swagger document for each discovered API version.
        //        // Note: you might choose to skip or document deprecated API versions differently.
        //        foreach (var description in provider.ApiVersionDescriptions)
        //        {
        //            options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
        //        }
        //    }

        //    private static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
        //    {
        //        var info = new OpenApiInfo()
        //        {
        //            Title = "GITHUB USER INFO MINIMAL API",
        //            Version = description.ApiVersion.ToString(),
        //            Description = "A Demo Minimla API using MediatR to get Github users basic Info.",
        //            Contact = new OpenApiContact() { Name = "Jiahua Tong", Email = "up432014@hotmail.com" },
        //            License = new OpenApiLicense() { Name = "MIT License", Url = new Uri("https://opensource.org/licenses/MIT") }
        //        };

        //        if (description.IsDeprecated)
        //        {
        //            info.Description += " [This API version has been deprecated]";
        //        }

        //        return info;
        //    }
        //}
        #endregion

        public static List<string> buildStringList(this List<string> list) {
            var strList = new List<string>();
            foreach (var item in list)
            {
               if( item.TryParse(out List<string> temp))
                    strList.AddRange(temp);
            }
            return strList;
        }
        public static bool TryParse(this string input,out List<string> results)
        {
            results = new List<string>();
            if(!string.IsNullOrEmpty(input.Trim()))
            {
                results.Add(input.Trim());
            }
            return results?.Count > 0;
        }
    }
}
