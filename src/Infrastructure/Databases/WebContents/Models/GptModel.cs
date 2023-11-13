namespace backend.Infrastructure.Databases.WebContents.Models;
public record GptModel : Entity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Icon { get; set; }
    public string Url { get; set; }
}
