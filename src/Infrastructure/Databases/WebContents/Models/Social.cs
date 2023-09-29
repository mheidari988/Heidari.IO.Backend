namespace backend.Infrastructure.Databases.WebContents.Models;
public record Social : Entity
{
    public string Title { get; set; }
    public string Icon { get; set; }
    public string Url { get; set; }
}
