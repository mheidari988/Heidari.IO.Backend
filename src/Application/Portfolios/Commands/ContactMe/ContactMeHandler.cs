namespace backend.Application.Portfolios.Commands.ContactMe;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

public class ContactMeHandler : IRequestHandler<ContactMeCommand, ContactMeResponse>
{
    private readonly IPortfoliosRepository portfoliosRepository;

    public ContactMeHandler(IPortfoliosRepository portfoliosRepository)
    {
        this.portfoliosRepository = portfoliosRepository;
    }

    public async Task<ContactMeResponse> Handle(ContactMeCommand request, CancellationToken cancellationToken)
    {
        return await this.portfoliosRepository.SaveContactMe(request, cancellationToken);
    }
}
