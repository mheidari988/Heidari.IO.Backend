namespace backend.Infrastructure.Databases.WebContents.Configuration;

using backend.Infrastructure.Databases.WebContents;
using backend.Infrastructure.Databases.WebContents.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class ExperienceTypeConfiguration : IEntityTypeConfiguration<Experience>
{
    public void Configure(EntityTypeBuilder<Experience> builder)
    {
        _ = builder.HasKey(e => e.Id);

        _ = builder.Property(e => e.Title)
            .IsRequired(ModelConsts.Experience.TitleIsRequired)
            .HasMaxLength(ModelConsts.Experience.TitleMaxLength);

        _ = builder.Property(e => e.Company)
            .IsRequired(ModelConsts.Experience.CompanyIsRequired)
            .HasMaxLength(ModelConsts.Experience.CompanyMaxLength);

        _ = builder.Property(e => e.Description)
            .IsRequired(ModelConsts.Experience.DescriptionIsRequired)
            .HasMaxLength(ModelConsts.Experience.DescriptionMaxLength);

        _ = builder.Property(e => e.CompanyUrl)
            .IsRequired(ModelConsts.Experience.CompanyUrlIsRequired)
            .HasMaxLength(ModelConsts.Experience.CompanyUrlMaxLength);

        _ = builder.Property(e => e.DateStarted)
            .IsRequired(ModelConsts.Experience.DateStartedIsRequired);

        _ = builder.Property(e => e.DateEnded)
            .IsRequired(ModelConsts.Experience.DateEndedIsRequired);
    }
}
