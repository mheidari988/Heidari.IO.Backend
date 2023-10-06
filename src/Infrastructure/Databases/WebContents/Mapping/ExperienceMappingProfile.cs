namespace backend.Infrastructure.Databases.WebContents.Mapping;
using AutoMapper;

public class ExperienceMappingProfile : Profile
{
    public ExperienceMappingProfile()
    {
        _ = this.CreateMap<Models.Experience, Application.Portfolios.Queries.GetPortfolio.Dtos.GetPortfolioExperienceDto>().ReverseMap();
        _ = this.CreateMap<Models.Experience, Application.Portfolios.Queries.GetExperiences.GetExperiencesResponse>().ReverseMap();
    }
}
