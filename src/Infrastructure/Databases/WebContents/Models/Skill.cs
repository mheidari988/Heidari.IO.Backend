namespace backend.Infrastructure.Databases.WebContents.Models;
public record Skill : Entity
{
    public string Title { get; set; }
    public string Description { get; set; }
}
