namespace backend.Infrastructure.Databases.WebContents.Configuration;

using backend.Infrastructure.Databases.WebContents;
using backend.Infrastructure.Databases.WebContents.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class SocialTypeConfiguration : IEntityTypeConfiguration<Social>
{
    public void Configure(EntityTypeBuilder<Social> builder)
    {
        _ = builder.HasKey(e => e.Id);

        _ = builder.Property(e => e.Title)
            .IsRequired(ModelConsts.Social.TitleIsRequired)
            .HasMaxLength(ModelConsts.Social.TitleMaxLength);

        _ = builder.Property(e => e.Url)
            .IsRequired(ModelConsts.Social.UrlIsRequired)
            .HasMaxLength(ModelConsts.Social.UrlMaxLength);

        _ = builder.Property(e => e.Icon)
            .IsRequired(ModelConsts.Social.IconIsRequired)
            .HasMaxLength(ModelConsts.Social.IconMaxLength);

        // 1:N relationship with Portfolio
        _ = builder.HasOne(e => e.Portfolio)
            .WithMany(e => e.Socials)
            .HasForeignKey(e => e.PortfolioId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
