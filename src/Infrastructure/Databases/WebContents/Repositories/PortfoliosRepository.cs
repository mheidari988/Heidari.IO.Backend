namespace backend.Infrastructure.Databases.WebContents.Repositories;

using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using backend.Application.Common.Exceptions;
using backend.Application.Portfolios;
using backend.Application.Portfolios.Commands.ContactMe;
using backend.Application.Portfolios.Queries.GetExperiences;
using backend.Application.Portfolios.Queries.GetPortfolio;
using backend.Infrastructure.Databases.WebContents.Extensions;
using backend.Infrastructure.Databases.WebContents.Models;
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
        // _ = this.context.Database.EnsureDeleted();

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
                .FirstOrDefaultAsync(cancellationToken) ?? throw new NotFoundException($"{nameof(Portfolio)} not found");

            // Since EFCore Does not suppurt filtering on Include for the CosmosDb, we need to filter manually
            result.Menus = result.Menus?.Where(m => m.IsActive).ToList();
            result.Socials = result.Socials?.Where(s => s.IsActive).ToList();
            result.Experiences = result.Experiences?.Where(e => e.IsActive).ToList();
            foreach (var experience in result.Experiences)
            {
                experience.Skills = experience.Skills?.Where(s => s.IsActive).ToList();
                experience.Links = experience.Links?.Where(l => l.IsActive).ToList();
            }

            result.Gpts.GptModels = result.Gpts.GptModels?.Where(g => g.IsActive).ToList();

            return this.mapper.Map<GetPortfolioResponse>(result);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            throw;
        }
    }

    public async Task<List<GetExperiencesResponse>> GetExperiencesAsync(GetExperiencesQuery requestQuery, CancellationToken cancellationToken = default)
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
                .FirstOrDefaultAsync(cancellationToken) ?? throw new NotFoundException("Portfolio not found");

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
            Debug.WriteLine(ex);
            throw;
        }
    }

    public async Task<ContactMeResponse> SaveContactMe(ContactMeCommand request, CancellationToken cancellationToken = default)
    {
        try
        {
            _ = await this.context.ContactMes.AddAsync(new ContactMe
            {
                FullName = request.FullName,
                Email = request.Email,
                Message = request.Message,
                Subject = request.Subject,
                DateCreated = this.dateTimeProvider.Now
            }, cancellationToken);

            var result = await this.context.SaveChangesAsync(cancellationToken);

            return new ContactMeResponse(Success: result > 0);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            throw;
        }
    }
}
