namespace backend.Application.Portfolios.Queries.GetExperiences;
using System;
using MediatR;

public class GetExperiencesQuery : IRequest<List<GetExperiencesResponse>>
{
    public Guid PortfolioId { get; set; }
    public string SearchTerm { get; set; }
    public List<string> Skills { get; set; }
}
