namespace backend.Infrastructure.Databases.WebContents.Models;
public record Link : Entity
{
    public string Title { get; set; }
    public string Url { get; set; }
}
