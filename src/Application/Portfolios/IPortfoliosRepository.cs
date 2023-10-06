namespace backend.Application.Portfolios;

using System.Collections.Generic;
using backend.Application.Portfolios.Queries.GetExperiences;
using backend.Application.Portfolios.Queries.GetPortfolio;

public interface IPortfoliosRepository
{
    Task<List<GetExperiencesResponse>> GetExperiences(GetExperiencesQuery requestQuery, CancellationToken cancellationToken = default);
    Task<GetPortfolioResponse> GetPortfolioAsync(CancellationToken cancellationToken = default);
}
