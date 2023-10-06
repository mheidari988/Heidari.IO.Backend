namespace backend.Application.Portfolios.Queries.GetPortfolio;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

public class GetPortfolioHandler : IRequestHandler<GetPortfolioQuery, GetPortfolioResponse>
{
    private readonly IPortfoliosRepository portfoliosRepository;

    public GetPortfolioHandler(IPortfoliosRepository portfoliosRepository)
    {
        this.portfoliosRepository = portfoliosRepository;
    }
    public async Task<GetPortfolioResponse> Handle(GetPortfolioQuery request, CancellationToken cancellationToken)
    {
        return await this.portfoliosRepository.GetPortfolioAsync(cancellationToken);
    }
}
