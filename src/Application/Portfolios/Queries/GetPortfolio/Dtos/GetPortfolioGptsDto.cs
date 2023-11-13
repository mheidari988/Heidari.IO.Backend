namespace backend.Application.Portfolios.Queries.GetPortfolio.Dtos;
public class GetPortfolioGptsDto
{
    public string Description { get; set; }
    public List<GetPortfolioGptModelDto> GptModels { get; set; }
}
