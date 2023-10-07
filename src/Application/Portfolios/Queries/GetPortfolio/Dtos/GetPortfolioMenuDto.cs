namespace backend.Application.Portfolios.Queries.GetPortfolio.Dtos;

using backend.Application.Common.Entities;

public record GetPortfolioMenuDto : Entity
{
    public string Title { get; set; }
    public string Url { get; set; }
    public string Slug { get; set; }
}
