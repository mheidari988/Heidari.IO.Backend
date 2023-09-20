namespace backend.Infrastructure.Databases.WebContents;

using backend.Infrastructure.Databases.WebContents.Models;
using Microsoft.EntityFrameworkCore;

internal class WebContentsDbContext : DbContext
{
    public WebContentsDbContext(DbContextOptions<WebContentsDbContext> options) : base(options)
    {
    }

    // TODO: Add DbSet properties here
    // ...
    public DbSet<Portfolio> Portfolios { get; set; }
    public DbSet<Menu> Menus { get; set; }
    public DbSet<Social> Socials { get; set; }
    public DbSet<Link> Links { get; set; }
    public DbSet<Experience> Experiences { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<ExperienceSkill> ExperienceSkills { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        _ = modelBuilder.ApplyConfigurationsFromAssembly(typeof(WebContentsDbContext).Assembly);
    }
}
