namespace backend.Infrastructure;

using Application.Authors;
using Application.Movies;
using Application.Reviews;
using backend.Application.Portfolios;
using backend.Infrastructure.Databases.WebContents;
using backend.Infrastructure.Databases.WebContents.Repositories;
using Databases.MoviesReviews;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleDateTimeProvider;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration, string environmentName)
    {
        _ = services.AddDbContext<MovieReviewsDbContext>(options => options.UseInMemoryDatabase($"Movies-{Guid.NewGuid()}"), ServiceLifetime.Singleton);

        _ = services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        _ = services.AddSingleton<EntityFrameworkMovieReviewsRepository>();


        _ = services.AddSingleton<IAuthorsRepository>(p => p.GetRequiredService<EntityFrameworkMovieReviewsRepository>());
        _ = services.AddSingleton<IMoviesRepository>(x => x.GetRequiredService<EntityFrameworkMovieReviewsRepository>());
        _ = services.AddSingleton<IReviewsRepository>(x => x.GetRequiredService<EntityFrameworkMovieReviewsRepository>());

        _ = services.AddSingleton<IDateTimeProvider, SystemDateTimeProvider>();


        // WebContents

        var cosmosDbSettings = configuration.GetSection("Cosmos");
        var accountEndpoint = cosmosDbSettings["AccountEndpoint"];
        var accountKey = cosmosDbSettings["AccountKey"];
        var databaseName = cosmosDbSettings["DatabaseName"];

        // If running locally, use the local settings from appsettings.json
        if (environmentName != "local")
        {
            accountEndpoint = configuration["COSMOS_ENDPOINT"];
            accountKey = configuration["COSMOS_KEY"];
            databaseName = configuration["COSMOS_DBNAME"];
        }

        _ = services.AddDbContext<WebContentsDbContext>(options => options.UseCosmos(
                accountEndpoint: accountEndpoint,
                accountKey: accountKey,
                databaseName: databaseName));

        _ = services.AddScoped<IPortfoliosRepository, PortfoliosRepository>();

        return services;
    }
}
