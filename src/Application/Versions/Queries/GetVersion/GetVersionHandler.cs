namespace backend.Application.Versions.Queries.GetVersion;

using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Entities;
using MediatR;

public class GetVersionHandler : IRequestHandler<GetVersionQuery, Version>
{
    public Task<Version> Handle(GetVersionQuery request, CancellationToken cancellationToken)
    {
        var version = new Version
        {
            FileVersion = $"{Assembly.GetEntryAssembly()?.GetCustomAttribute<AssemblyFileVersionAttribute>()?.Version}",
            InformationalVersion = $"{Assembly.GetEntryAssembly()?.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion}",
            Description = "This was coded in <a href=\"https://code.visualstudio.com/\" target=\"_blank\">Visual Studio Code</a> by yours truly. It was styled with <a href=\"https://developer.mozilla.org/en-US/docs/Web/CSS\" target=\"_blank\">CSS</a>, managed by <a href=\"https://dotnet.microsoft.com/en-us/\" target=\"_blank\">.NET Core backend</a>, Containerized by <a href=\"https://www.docker.com/\" target=\"_blank\">Docker</a>, and published on <a href=\"https://azure.microsoft.com/en-us/\" target=\"_blank\">Azure Cloud</a>.\r\n"
        };

        return Task.FromResult(version);
    }
}
