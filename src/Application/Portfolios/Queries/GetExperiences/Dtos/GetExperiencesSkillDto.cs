namespace backend.Application.Portfolios.Queries.GetExperiences.Dtos;
using backend.Application.Common.Entities;

public record GetExperiencesSkillDto : Entity
{
    public string Title { get; set; }
    public string Description { get; set; }
}
