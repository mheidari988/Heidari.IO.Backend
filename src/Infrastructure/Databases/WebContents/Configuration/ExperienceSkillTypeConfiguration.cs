namespace backend.Infrastructure.Databases.WebContents.Configuration;
using backend.Infrastructure.Databases.WebContents.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class ExperienceSkillTypeConfiguration : IEntityTypeConfiguration<ExperienceSkill>
{
    public void Configure(EntityTypeBuilder<ExperienceSkill> builder)
    {
        // N:N relationship with Experience and Skill

        _ = builder.HasKey(e => new { e.ExperienceId, e.SkillId });

        _ = builder.HasOne(e => e.Experience)
            .WithMany(e => e.ExperienceSkills)
            .HasForeignKey(e => e.ExperienceId);

        _ = builder.HasOne(e => e.Skill)
            .WithMany(e => e.ExperienceSkills)
            .HasForeignKey(e => e.SkillId);
    }
}
