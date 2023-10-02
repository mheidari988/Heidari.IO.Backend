namespace backend.Application.Portfolios.Queries.GetExperiences;
using System;
using System.Collections.Generic;
using backend.Application.Common.Entities;
using backend.Application.Portfolios.Queries.GetExperiences.Dtos;

public record GetExperiencesResponse : Entity
{
    public string Title { get; set; }
    public string Company { get; set; }
    public string Description { get; set; }
    public string CompanyUrl { get; set; }
    public DateTime DateStarted { get; set; }
    public DateTime? DateEnded { get; set; }
    public List<GetExperiencesSkillDto> Skills { get; set; }
    public List<GetExperiencesLinkDto> Links { get; set; }
}
