namespace backend.Infrastructure.Databases.WebContents.Configuration;

using backend.Infrastructure.Databases.WebContents;
using backend.Infrastructure.Databases.WebContents.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class MenuTypeConfiguration : IEntityTypeConfiguration<Menu>
{
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        _ = builder.Property(e => e.Title)
            .IsRequired(ModelConsts.Menu.TitleIsRequired)
            .HasMaxLength(ModelConsts.Menu.TitleMaxLength);

        _ = builder.Property(e => e.Url)
            .IsRequired(ModelConsts.Menu.UrlIsRequired)
            .HasMaxLength(ModelConsts.Menu.UrlMaxLength);

        // 1:N relationship with Portfolio
        _ = builder.HasOne(e => e.Portfolio)
            .WithMany(e => e.Menus)
            .HasForeignKey(e => e.PortfolioId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
