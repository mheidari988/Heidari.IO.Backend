namespace backend.Presentation.Endpoints;

using System.Diagnostics;
using backend.Application.Portfolios.Queries.GetExperiences;
using backend.Application.Portfolios.Queries.GetPortfolio;
using MediatR;

public static class PortfoliosEndpoints
{
    public static WebApplication MapPortfoliosEndpoints(this WebApplication app)
    {
        var root = app.MapGroup("/api/portfolio")
            .WithTags("portfolio")
            .WithOpenApi();

        _ = root.MapGet("/", GetPortfolio)
            .Produces<GetPortfolioResponse>()
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithSummary("Lookup the portfolio")
            .WithDescription("\n    GET /portfolio");

        _ = root.MapGet("/{id}/experiences", GetExperiences)
            .Produces<List<GetExperiencesResponse>>()
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithSummary("Lookup the experiences by Portfolio id")
            .WithDescription("\n    GET /portfolio/{id}/experiences");

        return app;
    }

    public static async Task<IResult> GetPortfolio(IMediator mediator)
    {
        try
        {
            return Results.Ok(await mediator.Send(new GetPortfolioQuery()));
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return Results.Problem(ex.StackTrace, ex.Message, StatusCodes.Status500InternalServerError);
        }
    }

    public static async Task<IResult> GetExperiences(Guid id, IMediator mediator)
    {
        try
        {
            return Results.Ok(await mediator.Send(new GetExperiencesQuery
            {
                PortfolioId = id
            }));
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return Results.Problem(ex.StackTrace, ex.Message, StatusCodes.Status500InternalServerError);
        }
    }
}
