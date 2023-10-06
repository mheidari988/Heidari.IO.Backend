namespace backend.Application;

using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[ExcludeFromCodeCoverage]
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        // TODO: Get the base address from configuration
        _ = services.AddHttpClient("azure-blob-storage", c => c.BaseAddress = new Uri("https://heidaristorage.blob.core.windows.net"));

        _ = services.AddMediatR(Assembly.GetExecutingAssembly());

        return services;
    }
}
