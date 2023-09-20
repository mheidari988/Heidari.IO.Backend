namespace backend.Infrastructure.Databases.WebContents.Configuration;

using backend.Infrastructure.Databases.WebContents;
using backend.Infrastructure.Databases.WebContents.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class SkillTypeConfiguration : IEntityTypeConfiguration<Skill>
{
    public void Configure(EntityTypeBuilder<Skill> builder)
    {
        _ = builder.HasKey(e => e.Id);

        _ = builder.Property(e => e.Title)
            .IsRequired(ModelConsts.Skill.TitleIsRequired)
            .HasMaxLength(ModelConsts.Skill.TitleMaxLength);

        _ = builder.Property(e => e.Description)
            .IsRequired(ModelConsts.Experience.DateEndedIsRequired)
            .HasMaxLength(ModelConsts.Skill.DescriptionMaxLength);
    }
}
