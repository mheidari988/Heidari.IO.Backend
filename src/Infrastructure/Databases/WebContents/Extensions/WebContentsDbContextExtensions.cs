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

        #region Add Experiences
        var experiences = new List<Experience>
        {
            new Experience
            {
                Title = "Software Developer",
                Company = "Arneca Technologies",
                CompanyUrl = "https://www.arneca.com/",
                Description = "The role encompasses developing resilient code for diverse client projects, including the insurance and healthcare sectors...",
                DateStarted = DateTime.Parse("May 2022"),
                DateEnded = null,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                Links = new List<Link>
                {
                    new Link { Title = "Arneca", Url = "https://www.arneca.com/", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                    new Link { Title = "Memorial", Url = "https://www.memorial.com.tr/en", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                    new Link { Title = "Amplicade", Url = "https://amplicade.com/", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow }
                },
                Skills = new List<Skill>
                {
                    new Skill { Title = "Asp.Net Core API", Description = "Used for building robust RESTful APIs.", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                    new Skill { Title = "CQRS", Description = "Architectural pattern for handling data manipulations.", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                    new Skill { Title = "MS SQL Server", Description = "Relational database management system by Microsoft.", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                    new Skill { Title = "PostgreSQL", Description = "Open-source relational database management system.", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                    new Skill { Title = "Elasticsearch", Description = "Search and analytics engine.", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                    new Skill { Title = "Redis", Description = "In-memory data store used for caching.", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                    new Skill { Title = "JavaScript", Description = "Programming language for web development.", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                    new Skill { Title = "TypeScript", Description = "Superset of JavaScript with static type definitions.", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                    new Skill { Title = "Angular", Description = "Web application framework.", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                    new Skill { Title = "React", Description = "Library for building user interfaces.", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                    new Skill { Title = "Next.js", Description = "React framework for server-rendered applications.", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                    new Skill { Title = "CSS", Description = "Styling language for web pages.", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                    new Skill { Title = "Docker", Description = "Platform for developing, shipping, and running applications in containers.", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                    new Skill { Title = "Linux", Description = "Unix-like, open-source operating system.", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                    new Skill { Title = "Azure", Description = "Cloud computing service from Microsoft.", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                    new Skill { Title = "AWS", Description = "Amazon's cloud computing platform.", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow }
                }
            },
            new Experience
            {
                Title = "Software Developer",
                Company = "Mat BioMedical",
                CompanyUrl = "http://www.matbiomedical.com/",
                Description = "The role involved developing web applications for water therapy devices...",
                DateStarted = DateTime.Parse("Feb 2021"),
                DateEnded = DateTime.Parse("May 2022"),
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                Links = new List<Link>
                {
                    new Link { Title = "AQUAMILL", Url = "http://www.matbiomedical.com/AquaMill.html", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                    new Link { Title = "Easy Gait", Url = "http://www.matbiomedical.com/Easy-Gait.html", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                    new Link { Title = "ISO KINETIK", Url = "http://www.matbiomedical.com/Power-Rehab.html", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                    new Link { Title = "StockSharp", Url = "https://stocksharp.com/", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                    new Link { Title = "Price Action Trading", Url = "https://en.wikipedia.org/wiki/Price_action_trading", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow }
                },
                Skills = new List<Skill>
                {
                    new Skill { Title = "Asp.Net MVC", Description = "Framework for building scalable web applications.", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                    new Skill { Title = "React", Description = "JavaScript library for building user interfaces.", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                    new Skill { Title = "CSS", Description = "Styling language for web pages.", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                    new Skill { Title = "jQuery", Description = "JavaScript library that simplifies client-side scripting.", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                    new Skill { Title = "SQL Server", Description = "Microsoft's relational database management system.", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                    new Skill { Title = "Redis", Description = "In-memory data store used for various purposes including caching.", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                    new Skill { Title = "Node JS", Description = "JavaScript runtime for server-side programming.", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                    new Skill { Title = "JavaScript", Description = "Versatile language for both client and server-side development.", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                    new Skill { Title = "TypeScript", Description = "JavaScript superset that allows for static typing.", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                    new Skill { Title = "Windows Forms Applications", Description = "Framework for building Windows desktop applications.", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                    new Skill { Title = "WPF Application", Description = "Framework for building rich desktop applications with advanced UI.", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                    new Skill { Title = "XAML", Description = "Markup language for initializing structured values and objects.", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                    new Skill { Title = "MySQL", Description = "Open-source relational database management system.", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                    new Skill { Title = "WordPress", Description = "Content management system primarily used for website creation.", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                    new Skill { Title = "Asp.Net Core API", Description = "Framework for building modern web APIs.", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                    new Skill { Title = "IIS", Description = "Web server for hosting web applications.", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow }
                }
            },
            new Experience
            {
                Title = "Software Developer",
                Company = "Negin Nassaj Asia",
                CompanyUrl = "http://senatex.ir",
                Description = "Worked on client websites using technologies like ASP.NET and front-end languages...",
                DateStarted = DateTime.Parse("Apr 2015"),
                DateEnded = DateTime.Parse("Oct 2020"),
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                Links = new List<Link>
                {
                    new Link { Title = "Booria Carpet Designer", Url = "https://booria.com/en-carpetdesigner-html/?lang=en", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                    new Link { Title = "Kavir Semnan", Url = "http://kavirtextile.com/index.html", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                    new Link { Title = "Behnia", Url = "https://behniafar.ir/", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow }
                },
                Skills = new List<Skill>
                {
                    new Skill { Title = ".Net Framework", Description = "Used for developing various types of applications on Windows.", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                    new Skill { Title = ".Net Core", Description = "Cross-platform framework for building modern applications.", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                    new Skill { Title = "Windows Forms", Description = "Library for creating Windows-based applications.", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                    new Skill { Title = "WPF Applications", Description = "Used for creating rich desktop applications with advanced UI features.", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                    new Skill { Title = "Asp.Net", Description = "Framework for building web applications.", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                    new Skill { Title = "SQL Server", Description = "Relational database management system by Microsoft.", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                    new Skill { Title = "Web Services", Description = "Used for creating interoperable machine-to-machine interactions.", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                    new Skill { Title = "Network Sockets", Description = "Enables network communication between devices.", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                    new Skill { Title = "TCP/IP", Description = "Core protocols of the internet protocol suite.", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                    new Skill { Title = "IIS", Description = "Web server for hosting anything on the web.", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                    new Skill { Title = "Windows Server", Description = "Server operating system by Microsoft.", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                    new Skill { Title = "CSS", Description = "Used for styling web pages.", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                    new Skill { Title = "HTML", Description = "Standard markup language for creating web pages.", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                    new Skill { Title = "jQuery", Description = "JavaScript library for client-side scripting.", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                    new Skill { Title = "Linux", Description = "Open-source Unix-like operating system.", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                    new Skill { Title = "VPS Administration", Description = "Managing virtual private servers for hosting.", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow }
                }
            },
            new Experience
            {
                Title = "Software Developer",
                Company = "Atra Dade Pardaz",
                CompanyUrl = "#",
                Description = "Played a key role in developing a .NET application to update diverse client websites...",
                DateStarted = DateTime.Parse("Jul 2013"),
                DateEnded = DateTime.Parse("Apr 2015"),
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                Links = new List<Link>(), // Empty list as there are no links for this experience
                Skills = new List<Skill>
                {
                    new Skill { Title = "Windows Forms Applications", Description = "Framework for building Windows desktop applications.", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                    new Skill { Title = "Access", Description = "Database management system from Microsoft.", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                    new Skill { Title = "MySQL", Description = "Open-source relational database management system.", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                    new Skill { Title = "SQL Server", Description = "Relational database management system by Microsoft.", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                    new Skill { Title = "WordPress", Description = "Content management system for website creation.", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                    new Skill { Title = "Joomla", Description = "Free and open-source content management system for web content.", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                    new Skill { Title = "Crystal Reports", Description = "Business intelligence application for creating reports.", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                    new Skill { Title = "User Experience", Description = "Focus on enhancing user satisfaction with a product.", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                    new Skill { Title = "VB 6", Description = "Legacy version of the Visual Basic programming language.", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                    new Skill { Title = "VB.Net", Description = "Object-oriented programming language that is an evolution of classic Visual Basic.", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                    new Skill { Title = ".Net Framework", Description = "Software framework for building Windows applications.", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                    new Skill { Title = "Telerik Controls", Description = "Set of UI controls for .NET applications.", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                    new Skill { Title = "Silverlight", Description = "Outdated framework for rich web-based applications.", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                    new Skill { Title = "Flash Objects", Description = "Used for embedding multimedia content, now largely obsolete.", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow }
                }
            }
        };
        portfolio.Experiences = experiences;
        #endregion

        _ = context.Add(portfolio);
        _ = context.SaveChanges();

        return context;
    }
}
