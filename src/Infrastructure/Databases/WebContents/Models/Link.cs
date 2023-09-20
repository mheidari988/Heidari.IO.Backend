namespace backend.Infrastructure.Databases.WebContents.Models;
using System;

internal record Link : Entity
{
    public string Title { get; set; }
    public string Url { get; set; }
    public Guid ExperienceId { get; set; }
    public Experience Experience { get; set; }
}
