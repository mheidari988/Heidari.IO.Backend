namespace backend.Infrastructure.Databases.WebContents.Repositories;

using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using backend.Application.Portfolios;
using backend.Application.Portfolios.Queries.GetExperiences;
using backend.Application.Portfolios.Queries.GetPortfolio;
using backend.Infrastructure.Databases.WebContents.Extensions;
using Microsoft.EntityFrameworkCore;
using SimpleDateTimeProvider;

public class PortfoliosRepository : IPortfoliosRepository
{
    private readonly WebContentsDbContext context;
    private readonly IDateTimeProvider dateTimeProvider;
    private readonly IMapper mapper;

    public PortfoliosRepository(WebContentsDbContext context, IDateTimeProvider dateTimeProvider, IMapper mapper)
    {
        this.context = context;
        this.dateTimeProvider = dateTimeProvider;
        this.mapper = mapper;

        // WARNING: Only if you need to refresh the database
        //_ = this.context.Database.EnsureDeleted();

        if (this.context != null && this.context.Database.EnsureCreated())
        {
            _ = this.context.AddData();
        }
    }

    public async Task<GetPortfolioResponse> GetPortfolioAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var result = await this.context.Portfolios
                .Include(p => p.Menus)
                .Include(p => p.Socials)
                .Include(p => p.Experiences)
                    .ThenInclude(e => e.Skills)
                .Include(p => p.Experiences)
                    .ThenInclude(e => e.Links)
                .AsNoTracking()
                .FirstOrDefaultAsync(cancellationToken);

            return this.mapper.Map<GetPortfolioResponse>(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    public async Task<List<GetExperiencesResponse>> GetExperiences(GetExperiencesQuery requestQuery, CancellationToken cancellationToken = default)
    {
        try
        {
            var portfolio = await this.context.Portfolios
                .Where(p => p.Id == requestQuery.PortfolioId)
                .Include(e => e.Experiences)
                    .ThenInclude(e => e.Skills)
                .Include(e => e.Experiences)
                    .ThenInclude(e => e.Links)
                .AsNoTracking()
                .FirstOrDefaultAsync(cancellationToken);

            if (portfolio == null)
            {
                return null;
            }

            var experiences = portfolio.Experiences
                .Where(e => string.IsNullOrEmpty(requestQuery.SearchTerm) ||
                    e.Title.Contains(requestQuery.SearchTerm) ||
                    e.Description.Contains(requestQuery.SearchTerm) ||
                    e.Company.Contains(requestQuery.SearchTerm))
                .ToList();

            return this.mapper.Map<List<GetExperiencesResponse>>(experiences);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }
}
