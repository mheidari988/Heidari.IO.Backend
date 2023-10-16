namespace backend.Application.Portfolios;

using System.Collections.Generic;
using backend.Application.Portfolios.Commands.ContactMe;
using backend.Application.Portfolios.Queries.GetExperiences;
using backend.Application.Portfolios.Queries.GetPortfolio;

public interface IPortfoliosRepository
{
    Task<List<GetExperiencesResponse>> GetExperiencesAsync(GetExperiencesQuery requestQuery, CancellationToken cancellationToken = default);
    Task<GetPortfolioResponse> GetPortfolioAsync(CancellationToken cancellationToken = default);
    Task<ContactMeResponse> SaveContactMe(ContactMeCommand request, CancellationToken cancellationToken = default);
}
