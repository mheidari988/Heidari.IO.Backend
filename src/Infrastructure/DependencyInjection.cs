namespace backend.Infrastructure;

using Application.Authors;
using Application.Movies;
using Application.Reviews;
using backend.Application.Portfolios;
using backend.Infrastructure.Databases.WebContents;
using backend.Infrastructure.Databases.WebContents.Repositories;
using Databases.MoviesReviews;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SimpleDateTimeProvider;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        _ = services.AddDbContext<MovieReviewsDbContext>(options => options.UseInMemoryDatabase($"Movies-{Guid.NewGuid()}"), ServiceLifetime.Singleton);

        _ = services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        _ = services.AddSingleton<EntityFrameworkMovieReviewsRepository>();


        _ = services.AddSingleton<IAuthorsRepository>(p => p.GetRequiredService<EntityFrameworkMovieReviewsRepository>());
        _ = services.AddSingleton<IMoviesRepository>(x => x.GetRequiredService<EntityFrameworkMovieReviewsRepository>());
        _ = services.AddSingleton<IReviewsRepository>(x => x.GetRequiredService<EntityFrameworkMovieReviewsRepository>());

        _ = services.AddSingleton<IDateTimeProvider, SystemDateTimeProvider>();


        // WebContents

        _ = services.AddDbContext<WebContentsDbContext>(options => options.UseInMemoryDatabase($"WebContents-{Guid.NewGuid()}"), ServiceLifetime.Singleton);
        _ = services.AddSingleton<IPortfoliosRepository, PortfoliosRepository>();

        return services;
    }
}
