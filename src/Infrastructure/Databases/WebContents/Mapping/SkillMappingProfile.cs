namespace backend.Infrastructure.Databases.WebContents.Mapping;
using AutoMapper;

public class SkillMappingProfile : Profile
{
    public SkillMappingProfile()
    {
        _ = this.CreateMap<Models.Skill, Application.Portfolios.Queries.GetPortfolio.Dtos.GetPortfolioSkillDto>().ReverseMap();
        _ = this.CreateMap<Models.Skill, Application.Portfolios.Queries.GetExperiences.Dtos.GetExperiencesSkillDto>().ReverseMap();
    }
}
