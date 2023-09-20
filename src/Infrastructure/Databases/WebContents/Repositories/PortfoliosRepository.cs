namespace backend.Infrastructure.Databases.WebContents.Repositories;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using backend.Application.Portfolios;
using backend.Application.Portfolios.Queries.GetPortfolio;
using backend.Infrastructure.Databases.WebContents.Extensions;
using Microsoft.EntityFrameworkCore;
using SimpleDateTimeProvider;

internal class PortfoliosRepository : IPortfoliosRepository
{
    private readonly WebContentsDbContext context;
    private readonly IDateTimeProvider dateTimeProvider;
    private readonly IMapper mapper;

    public PortfoliosRepository(WebContentsDbContext context, IDateTimeProvider dateTimeProvider, IMapper mapper)
    {
        this.context = context;
        this.dateTimeProvider = dateTimeProvider;
        this.mapper = mapper;

        if (this.context != null)
        {
            _ = this.context.Database.EnsureDeleted();
            _ = this.context.Database.EnsureCreated();
            _ = this.context.AddData();
        }
    }

    public async Task<GetPortfolioResponse> GetPortfolioAsync(CancellationToken cancellationToken = default)
    {
        var result = await this.context.Portfolios
            .Include(p => p.Menus)
            .Include(p => p.Socials)
            .AsNoTracking()
            .FirstOrDefaultAsync(cancellationToken);

        return this.mapper.Map<GetPortfolioResponse>(result);
    }
}
