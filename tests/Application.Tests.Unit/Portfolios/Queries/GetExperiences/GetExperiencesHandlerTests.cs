namespace backend.Application.Tests.Unit.Portfolios.Queries.GetExperiences;

using backend.Application.Common.Exceptions;
using backend.Application.Portfolios;
using backend.Application.Portfolios.Queries.GetExperiences;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Shouldly;
using Xunit;

public class GetExperiencesHandlerTests
{

    [Fact]
    public async Task Handle_WithValidQuery_ReturnsExpectedExperienceList()
    {
        // Arrange
        var query = new GetExperiencesQuery
        {
            PortfolioId = Guid.Empty
        };

        var context = Substitute.For<IPortfoliosRepository>();
        var handler = new GetExperiencesHandler(context);
        var token = new CancellationTokenSource().Token;

        _ = context.GetExperiencesAsync(Arg.Any<GetExperiencesQuery>(), token).Returns(Task.FromResult(new List<GetExperiencesResponse>
        {
            new GetExperiencesResponse
            {
                Company = "Oregon",
                Description = "Description 1",
            },
            new GetExperiencesResponse
            {
                Company = "Texas",
                Description = "Description 2",
            }
        }));

        // Act
        var result = await handler.Handle(query, token);

        // Assert
        _ = await context.Received(1).GetExperiencesAsync(query, token);
        _ = result.ShouldNotBeNull();
        _ = result.ShouldBeOfType<List<GetExperiencesResponse>>();

        result.Count.ShouldBe(2);
        result[0].Company.ShouldBe("Oregon");
        result[0].Description.ShouldBe("Description 1");
        result[1].Company.ShouldBe("Texas");
        result[1].Description.ShouldBe("Description 2");
    }

    [Fact]
    public async Task Handle_ShouldThrowException_NotFound()
    {
        // Arrange
        var query = new GetExperiencesQuery
        {
            PortfolioId = Guid.Empty
        };

        var context = Substitute.For<IPortfoliosRepository>();
        var handler = new GetExperiencesHandler(context);
        var token = new CancellationTokenSource().Token;

        _ = context.GetExperiencesAsync(Arg.Any<GetExperiencesQuery>(), token).Throws(new NotFoundException("Experience not found"));

        // Act
        var exception = await Should.ThrowAsync<NotFoundException>(async () => await handler.Handle(query, token));

        // Assert
        _ = await context.Received(1).GetExperiencesAsync(query, token);

        exception.Message.ShouldBe("Experience not found");
    }
}
