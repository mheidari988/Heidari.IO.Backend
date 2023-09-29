namespace backend.Presentation.Endpoints;

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
            return Results.Problem(ex.StackTrace, ex.Message, StatusCodes.Status500InternalServerError);
        }
    }
}
