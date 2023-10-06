namespace backend.Infrastructure.Databases.WebContents.Mapping;
using AutoMapper;

internal class PortfolioMappingProfile : Profile
{
    public PortfolioMappingProfile()
    {
        _ = this.CreateMap<Models.Portfolio, Application.Portfolios.Queries.GetPortfolio.GetPortfolioResponse>()
            .ReverseMap();
    }
}
