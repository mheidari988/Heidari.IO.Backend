namespace backend.Infrastructure.Databases.WebContents.Configuration;

using backend.Infrastructure.Databases.WebContents;
using backend.Infrastructure.Databases.WebContents.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class PortfolioTypeConfiguration : IEntityTypeConfiguration<Portfolio>
{
    public void Configure(EntityTypeBuilder<Portfolio> builder)
    {
        _ = builder.HasKey(e => e.Id);

        _ = builder.Property(e => e.Name)
            .IsRequired(ModelConsts.Portfolio.NameIsRequired)
            .HasMaxLength(ModelConsts.Portfolio.NameMaxLength);

        _ = builder.Property(e => e.Title)
            .IsRequired(ModelConsts.Portfolio.TitleIsRequired)
            .HasMaxLength(ModelConsts.Portfolio.TitleMaxLength);

        _ = builder.Property(e => e.Subtitle)
            .IsRequired(ModelConsts.Portfolio.SubtitleIsRequired)
            .HasMaxLength(ModelConsts.Portfolio.SubtitleMaxLength);

        _ = builder.Property(e => e.Description)
            .IsRequired(ModelConsts.Portfolio.DescriptionIsRequired)
            .HasMaxLength(ModelConsts.Portfolio.DescriptionMaxLength);
    }
}
