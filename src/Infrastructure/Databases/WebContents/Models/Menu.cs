namespace backend.Infrastructure.Databases.WebContents.Models;
using System;

internal record Menu : Entity
{
    public string Title { get; set; }
    public string Url { get; set; }
    public Guid PortfolioId { get; set; }
    public Portfolio Portfolio { get; set; }
}