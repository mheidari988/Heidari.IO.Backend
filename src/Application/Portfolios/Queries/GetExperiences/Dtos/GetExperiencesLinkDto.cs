namespace backend.Application.Portfolios.Queries.GetExperiences.Dtos;
using backend.Application.Common.Entities;

public record GetExperiencesLinkDto : Entity
{
    public string Title { get; set; }
    public string Url { get; set; }
}
