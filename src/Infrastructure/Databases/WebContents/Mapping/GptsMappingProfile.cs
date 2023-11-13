namespace backend.Infrastructure.Databases.WebContents.Mapping;
using AutoMapper;

public class GptsMappingProfile : Profile
{
    public GptsMappingProfile()
    {
        _ = this.CreateMap<Models.Gpts, Application.Portfolios.Queries.GetPortfolio.Dtos.GetPortfolioGptsDto>();
    }
}
