namespace backend.Infrastructure.Databases.WebContents.Mapping;
using AutoMapper;

internal class MenuMappingProfile : Profile
{
    public MenuMappingProfile()
    {
        _ = this.CreateMap<Models.Menu, Application.Portfolios.Queries.GetPortfolio.Dtos.MenuDto>()
            .ReverseMap();
    }
}
