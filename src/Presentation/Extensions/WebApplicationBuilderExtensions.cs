namespace backend.Presentation.Extensions;

using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Application;
using FluentValidation;
using Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Serilog;

[ExcludeFromCodeCoverage]
public static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder ConfigureApplicationBuilder(this WebApplicationBuilder builder)
    {
        #region CORS

        // Add CORS policy for all origins, all methods and all headers if the environment is Development
        _ = builder.Services.AddCors(options =>
                options.AddPolicy("AllowAll", builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()));
        #endregion

        #region Logging

        _ = builder.Host.UseSerilog((hostContext, loggerConfiguration) =>
        {
            var assembly = Assembly.GetEntryAssembly();

            _ = loggerConfiguration.ReadFrom.Configuration(hostContext.Configuration)
                .Enrich.WithProperty(
                    "Assembly Version",
                    assembly?.GetCustomAttribute<AssemblyFileVersionAttribute>()?.Version)
                .Enrich.WithProperty(
                    "Assembly Informational Version",
                    assembly?.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion);
        });

        #endregion Logging

        #region Serialisation

        _ = builder.Services.Configure<JsonOptions>(opt =>
        {
            opt.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            opt.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            opt.SerializerOptions.PropertyNameCaseInsensitive = true;
            opt.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            opt.SerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
        });

        #endregion Serialisation

        #region Swagger

        var ti = CultureInfo.CurrentCulture.TextInfo;

        _ = builder.Services.AddEndpointsApiExplorer();
        _ = builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Version = "v1",
                    Title = $"www.heidari.io backend API - {ti.ToTitleCase(builder.Environment.EnvironmentName)}",
                    Description = "API endpoints that we will use in the www.heidari.io frontend project.",
                    Contact = new OpenApiContact
                    {
                        Name = "heidari.io backend API",
                        Email = "reza@heidari.io",
                        Url = new Uri("https://github.com/mheidari988/Heidari.IO.Backend")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "heidari.io backend API - License - MIT",
                        Url = new Uri("https://opensource.org/licenses/MIT")
                    },
                    TermsOfService = new Uri("https://github.com/mheidari988/Heidari.IO.Backend")
                });

            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            options.DocInclusionPredicate((name, api) => true);
        });

        #endregion Swagger

        #region Validation

        //_ = builder.Services.AddSingleton(typeof(IEndpointFilter), typeof(ValidationFilter<>));
        _ = builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        #endregion Validation

        #region Project Dependencies

        _ = builder.Services.AddInfrastructure(builder.Configuration, builder.Environment.EnvironmentName);
        _ = builder.Services.AddApplication();

        #endregion Project Dependencies

        return builder;
    }
}
