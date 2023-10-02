namespace backend.Infrastructure.Databases.WebContents.Mapping;
using AutoMapper;

internal class SocialMappingProfile : Profile
{
    public SocialMappingProfile()
    {
        _ = this.CreateMap<Models.Social, Application.Portfolios.Queries.GetPortfolio.Dtos.GetPortfolioSocialDto>()
            .ReverseMap();
    }
}
