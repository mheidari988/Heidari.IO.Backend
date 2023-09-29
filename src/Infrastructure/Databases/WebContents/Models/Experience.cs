namespace backend.Infrastructure.Databases.WebContents.Models;
using System;
using System.Collections.Generic;

public record Experience : Entity
{
    public string Title { get; set; }
    public string Company { get; set; }
    public string Description { get; set; }
    public string CompanyUrl { get; set; }
    public DateTime DateStarted { get; set; }
    public DateTime? DateEnded { get; set; }
    public ICollection<Link> Links { get; set; }
    public ICollection<Skill> Skills { get; set; }
}
