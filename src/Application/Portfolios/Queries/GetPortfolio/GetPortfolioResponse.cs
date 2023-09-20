namespace backend.Application.Portfolios.Queries.GetPortfolio;

using backend.Application.Portfolios.Queries.GetPortfolio.Dtos;

public class GetPortfolioResponse
{
    public string Name { get; set; }
    public string Title { get; set; }
    public string Subtitle { get; set; }
    public string Description { get; set; }
    public List<MenuDto> Menus { get; set; }
    public List<SocialDto> Socials { get; set; }
}