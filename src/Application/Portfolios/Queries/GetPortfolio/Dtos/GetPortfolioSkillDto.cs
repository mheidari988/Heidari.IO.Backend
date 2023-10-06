namespace backend.Application.Portfolios.Queries.GetPortfolio.Dtos;
using backend.Application.Common.Entities;

public record GetPortfolioSkillDto : Entity
{
    public string Title { get; set; }
    public string Description { get; set; }
}
