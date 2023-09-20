namespace backend.Infrastructure.Databases.WebContents.Configuration;

using backend.Infrastructure.Databases.WebContents;
using backend.Infrastructure.Databases.WebContents.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class LinkTypeConfiguration : IEntityTypeConfiguration<Link>
{
    public void Configure(EntityTypeBuilder<Link> builder)
    {
        _ = builder.HasKey(l => l.Id);

        _ = builder.Property(l => l.Title)
            .IsRequired(ModelConsts.Link.TitleIsRequired)
            .HasMaxLength(ModelConsts.Link.TitleMaxLength);

        _ = builder.Property(l => l.Url)
            .IsRequired(ModelConsts.Link.UrlIsRequired)
            .HasMaxLength(ModelConsts.Link.UrlMaxLength);

        // 1:N relationship with Experience
        _ = builder.HasOne(l => l.Experience)
            .WithMany(e => e.Links)
            .HasForeignKey(l => l.ExperienceId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
