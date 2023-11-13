namespace backend.Infrastructure.Databases.WebContents.Mapping;
using AutoMapper;

public class GptModelMappingProfile : Profile
{
    public GptModelMappingProfile()
    {
        _ = this.CreateMap<Models.GptModel, Application.Portfolios.Queries.GetPortfolio.Dtos.GetPortfolioGptModelDto>();
    }
}
