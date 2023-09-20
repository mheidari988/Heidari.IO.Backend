namespace backend.Infrastructure.Databases.WebContents.Extensions;
using System;
using backend.Infrastructure.Databases.WebContents.Models;

internal static class WebContentsDbContextExtensions
{
    public static WebContentsDbContext AddData(this WebContentsDbContext context)
    {
        #region Add Portfolio Data
        var portfolio = new Portfolio
        {
            Id = Guid.NewGuid(),
            Name = "Reza Heidari",
            Title = "Full Stack Software Developer",
            Subtitle = "From Figma to deployment, I can build web applications, and I'm also proficient in crafting Windows and WPF apps.",
            Description = "<p>In 2012, I embarked on a journey into the world of coding and software development by experimenting with both Web and Windows Applications. Since then, I've had the opportunity to develop software for various fields, including fields like <a href=\"#\">healthcare</a>, <a href=\"#\">insurance</a>, academic collaborations, <a href=\"#\">small startups</a>, and <a href=\"#\">wonderful corporations</a>, working with a wide array of individual developers.</p><p>These days, I create user-friendly applications and online experiences. My work starts with gathering information and planning. I take care of both the behind-the-scenes part (backend) of the application, including managing databases, and the visual part (frontend), leveraging wide range of tools. When everything's ready, I use various methods, including Docker and cloud services, or in some cases, traditional ways of deployment, to put the application live for users.</p><p>Away from the keyboard, I find joy in walking with my favorite tunes, spending cherished moments with my wife and our amusing cat, or spending time around <a href=\"https://www.itu.edu.tr/en\" target=\"_blank\">Istanbul Technical University</a>.</p>",
            DateCreated = DateTime.UtcNow,
            DateModified = DateTime.UtcNow,
        };
        #endregion

        #region Add Portfolio Menu Data
        var menus = new List<Menu>
        {
            new Menu
            {
                Title = "Download CV",
                Url = "#cv",
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
            }
        };
        portfolio.Menus = menus;
        #endregion

        #region Add Portfolio Social Data
        var socials = new List<Social>
        {
            new Social
            {
                Title = "GitHub",
                Icon = "github.png",
                Url = "https://github.com/mheidari988",
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow
            },
            new Social
            {
                Title = "LinkedIn",
                Icon = "linkedin.png",
                Url = "https://www.linkedin.com/in/mohy/",
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow
            },
            new Social
            {
                Title = "Stackoverflow",
                Icon = "stackoverflow.png",
                Url = "https://stackoverflow.com/users/6691714/reza-heidari",
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow
            },
            new Social
            {
                Title = "Twitter",
                Icon = "twitter.png",
                Url = "https://twitter.com/mhei988",
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow
            },
            new Social
            {
                Title = "Discord",
                Icon = "discord.png",
                Url = "https://discordapp.com/users/reza0",
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow
            }
        };
        portfolio.Socials = socials;
        #endregion

        _ = context.Add(portfolio);
        _ = context.SaveChanges();

        return context;
    }
}
