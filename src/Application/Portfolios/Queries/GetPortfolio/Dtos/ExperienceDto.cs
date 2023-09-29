namespace backend.Application.Portfolios.Queries.GetPortfolio.Dtos;
using System;
using System.Collections.Generic;

public class ExperienceDto
{
    public string Title { get; set; }
    public string Company { get; set; }
    public string Description { get; set; }
    public string CompanyUrl { get; set; }
    public DateTime DateStarted { get; set; }
    public DateTime? DateEnded { get; set; }
    public List<SkillDto> Skills { get; set; }
    public List<LinkDto> Links { get; set; }
}
