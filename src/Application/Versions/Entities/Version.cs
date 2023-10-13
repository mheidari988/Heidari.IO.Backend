namespace backend.Application.Versions.Entities;

public class Version
{
    public string FileVersion { get; init; }
    public string InformationalVersion { get; init; }
    public string Description { get; set; }
}
