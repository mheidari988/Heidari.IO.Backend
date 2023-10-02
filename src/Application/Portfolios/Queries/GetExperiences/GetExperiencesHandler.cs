namespace backend.Application.Portfolios.Queries.GetExperiences;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

public class GetExperiencesHandler : IRequestHandler<GetExperiencesQuery, List<GetExperiencesResponse>>
{
    private readonly IPortfoliosRepository portfoliosRepository;

    public GetExperiencesHandler(IPortfoliosRepository portfoliosRepository)
    {
        this.portfoliosRepository = portfoliosRepository;
    }

    public Task<List<GetExperiencesResponse>> Handle(GetExperiencesQuery request, CancellationToken cancellationToken)
    {
        return this.portfoliosRepository.GetExperiences(request, cancellationToken);
    }
}
