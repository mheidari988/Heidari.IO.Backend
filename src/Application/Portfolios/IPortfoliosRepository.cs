namespace backend.Application.Portfolios;

using backend.Application.Portfolios.Queries.GetPortfolio;

public interface IPortfoliosRepository
{
    Task<GetPortfolioResponse> GetPortfolioAsync(CancellationToken cancellationToken = default);
}
