namespace backend.Presentation.Endpoints;

using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using backend.Application.Portfolios.Commands.ContactMe;
using backend.Application.Portfolios.Commands.VerifyAndDownloadCv;
using backend.Application.Portfolios.Queries.GetExperiences;
using backend.Application.Portfolios.Queries.GetPortfolio;
using backend.Presentation.Validators;
using FluentValidation;
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

        _ = root.MapPost("/download-file", VerifyAndDownloadCv)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithSummary("Verify code and download file")
            .WithDescription("\n    POST /portfolio/download-file");

        _ = root.MapPost("/contact", ContactMe)
            .Produces<ContactMeResponse>()
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithSummary("Contact us form")
            .WithDescription("\n    POST /portfolio/contact");

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

    public static async Task<IResult> VerifyAndDownloadCv(VerifyAndDownloadCvCommand command, IMediator mediator)
    {
        try
        {
            var response = await mediator.Send(command);
            return Results.File(response.CvFileStream, response.CvFileMimeType, response.CvFileName);
        }
        catch (System.ComponentModel.DataAnnotations.ValidationException)
        {
            return Results.BadRequest("Invalid code.");
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return Results.Problem(ex.StackTrace, ex.Message, StatusCodes.Status500InternalServerError);
        }
    }

    public static async Task<IResult> ContactMe(ContactMeCommand command, IMediator mediator)
    {
        try
        {
            var validator = new ContactMeValidator();
            var validationResult = await validator.ValidateAsync(command);
            if (!validationResult.IsValid)
            {
                return Results.BadRequest(validationResult.Errors);
            }

            var response = await mediator.Send(command);
            return Results.Ok(response);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return Results.Problem(ex.StackTrace, ex.Message, StatusCodes.Status500InternalServerError);
        }
    }
}
