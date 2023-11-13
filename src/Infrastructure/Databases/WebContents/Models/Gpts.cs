namespace backend.Infrastructure.Databases.WebContents.Models;
public record Gpts : Entity
{
    public string Description { get; set; }
    public List<GptModel> GptModels { get; set; }
}
