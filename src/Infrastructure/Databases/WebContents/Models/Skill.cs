namespace backend.Infrastructure.Databases.WebContents.Models;
using System.Collections.Generic;

internal record Skill : Entity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public ICollection<ExperienceSkill> ExperienceSkills { get; set; }
}
