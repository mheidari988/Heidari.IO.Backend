namespace backend.Application.Portfolios.Queries.GetPortfolio.Dtos;

using backend.Application.Common.Entities;

public record SocialDto : Entity
{
    public string Title { get; set; }
    public string Icon { get; set; }
    public string Url { get; set; }
}
