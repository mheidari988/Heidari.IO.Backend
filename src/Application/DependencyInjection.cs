namespace backend.Application;

using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using reCAPTCHA.AspNetCore;

[ExcludeFromCodeCoverage]
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        // TODO: Get the base address from configuration
        _ = services.AddHttpClient("azure-blob-storage", c => c.BaseAddress = new Uri("https://heidaristorage.blob.core.windows.net"));

        _ = services.AddMediatR(config => config.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

        _ = services.Configure<RecaptchaSettings>(configuration.GetSection("RecaptchaSettings"));
        _ = services.AddTransient<IRecaptchaService, RecaptchaService>();

        return services;
    }
}
