namespace backend.Infrastructure.Databases.WebContents.Models;
internal record Portfolio : Entity
{
    public string Name { get; set; }
    public string Title { get; set; }
    public string Subtitle { get; set; }
    public string Description { get; set; }
    public ICollection<Menu> Menus { get; set; }
    public ICollection<Social> Socials { get; set; }
}
