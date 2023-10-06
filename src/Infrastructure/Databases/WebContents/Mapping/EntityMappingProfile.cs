namespace backend.Infrastructure.Databases.WebContents.Mapping;
using AutoMapper;

internal class EntityMappingProfile : Profile
{
    public EntityMappingProfile()
    {
        _ = this.CreateMap<Models.Entity, Application.Common.Entities.Entity>()
            .ReverseMap();
    }
}
