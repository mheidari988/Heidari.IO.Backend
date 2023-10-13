namespace backend.Application.Portfolios.Commands.ContactMe;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using reCAPTCHA.AspNetCore;

public class ContactMeHandler : IRequestHandler<ContactMeCommand, ContactMeResponse>
{
    private readonly IPortfoliosRepository portfoliosRepository;
    private readonly IRecaptchaService recaptchaService;

    public ContactMeHandler(
        IPortfoliosRepository portfoliosRepository,
        IRecaptchaService recaptchaService)
    {
        this.portfoliosRepository = portfoliosRepository;
        this.recaptchaService = recaptchaService;
    }

    public async Task<ContactMeResponse> Handle(ContactMeCommand request, CancellationToken cancellationToken)
    {
        var recaptcha = await this.recaptchaService.Validate(request.RecaptchaToken);

        if (!recaptcha.success)
        {
            return new ContactMeResponse(Success: false);
        }

        return await this.portfoliosRepository.SaveContactMe(request, cancellationToken);
    }
}
