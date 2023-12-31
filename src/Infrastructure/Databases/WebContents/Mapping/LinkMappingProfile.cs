namespace backend.Infrastructure.Databases.WebContents.Mapping;
using AutoMapper;

public class LinkMappingProfile : Profile
{
    public LinkMappingProfile()
    {
        _ = this.CreateMap<Models.Link, Application.Portfolios.Queries.GetPortfolio.Dtos.GetPortfolioLinkDto>().ReverseMap();
        _ = this.CreateMap<Models.Link, Application.Portfolios.Queries.GetExperiences.Dtos.GetExperiencesLinkDto>().ReverseMap();
    }
}
