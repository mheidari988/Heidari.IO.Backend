namespace backend.Infrastructure.Databases.WebContents.Models;
using System;

internal abstract record Entity
{
    public Guid Id { get; init; }
    public DateTime DateCreated { get; init; }
    public DateTime DateModified { get; set; }
}
