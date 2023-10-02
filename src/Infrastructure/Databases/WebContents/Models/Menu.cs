namespace backend.Infrastructure.Databases.WebContents.Models;
public record Menu : Entity
{
    public string Title { get; set; }
    public string Url { get; set; }
    public bool IsExternal { get; set; }
}
