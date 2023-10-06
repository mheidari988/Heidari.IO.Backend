namespace backend.Infrastructure.Databases.WebContents.Models;
using System;

public abstract record Entity
{
    public Guid Id { get; init; }
    public DateTime DateCreated { get; init; }
    public DateTime DateModified { get; set; }
}
