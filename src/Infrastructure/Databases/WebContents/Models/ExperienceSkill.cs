namespace backend.Infrastructure.Databases.WebContents.Models;
using System;

internal record ExperienceSkill : Entity
{
    public Guid ExperienceId { get; set; }
    public Experience Experience { get; set; }
    public Guid SkillId { get; set; }
    public Skill Skill { get; set; }
}
