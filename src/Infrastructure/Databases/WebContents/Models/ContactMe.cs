namespace backend.Infrastructure.Databases.WebContents.Models;
public record ContactMe : Entity
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }
}
