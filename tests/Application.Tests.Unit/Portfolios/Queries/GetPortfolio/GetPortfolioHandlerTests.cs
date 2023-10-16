namespace backend.Application.Tests.Unit.Portfolios.Queries.GetPortfolio;
using System.Threading.Tasks;
using backend.Application.Common.Exceptions;
using backend.Application.Portfolios;
using backend.Application.Portfolios.Queries.GetPortfolio;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Shouldly;
using Xunit;

public class GetPortfolioHandlerTests
{
    [Fact]
    public async Task Handle_ShouldPassThrough_Query()
    {
        // Arrange
        var query = new GetPortfolioQuery();

        var context = Substitute.For<IPortfoliosRepository>();
        var handler = new GetPortfolioHandler(context);
        var cancellationToken = new CancellationTokenSource().Token;

        _ = context.GetPortfolioAsync(cancellationToken).Returns(Task.FromResult(new GetPortfolioResponse
        {
            Name = "Name",
            Title = "Title",
            Description = "Description",
            Subtitle = "Subtitle"
        }));

        // Act
        var result = await handler.Handle(query, cancellationToken);

        // Assert
        _ = await context.Received(1).GetPortfolioAsync(cancellationToken);

        _ = result.ShouldNotBeNull();
        _ = result.ShouldBeOfType<GetPortfolioResponse>();

        result.Name.ShouldBe("Name");
        result.Title.ShouldBe("Title");
        result.Description.ShouldBe("Description");
        result.Subtitle.ShouldBe("Subtitle");
    }

    [Fact]
    public async Task Handle_ShouldThrowException_NotFound()
    {
        // Arrange
        var query = new GetPortfolioQuery();

        var context = Substitute.For<IPortfoliosRepository>();
        var handler = new GetPortfolioHandler(context);
        var token = new CancellationTokenSource().Token;

        _ = context.GetPortfolioAsync(token).Throws(new NotFoundException("Portfolio not found"));

        // Act
        var exception = await Should.ThrowAsync<NotFoundException>(async () => await handler.Handle(query, token));

        // Assert
        _ = await context.Received(1).GetPortfolioAsync(token);

        exception.Message.ShouldBe("Portfolio not found");
    }
}
