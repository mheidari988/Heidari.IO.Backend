namespace backend.Application.Portfolios.Queries.GetPortfolio;

using backend.Application.Common.Entities;
using backend.Application.Portfolios.Queries.GetPortfolio.Dtos;

public record GetPortfolioResponse : Entity
{
    public string Name { get; set; }
    public string Title { get; set; }
    public string Subtitle { get; set; }
    public string Description { get; set; }
    public List<GetPortfolioMenuDto> Menus { get; set; }
    public List<GetPortfolioSocialDto> Socials { get; set; }
    public List<GetPortfolioExperienceDto> Experiences { get; set; }
    public GetPortfolioGptsDto Gpts { get; set; }
}
