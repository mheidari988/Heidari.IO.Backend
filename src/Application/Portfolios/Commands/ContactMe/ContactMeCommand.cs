namespace backend.Application.Portfolios.Commands.ContactMe;
using MediatR;

public record ContactMeCommand(string FullName, string Email, string Subject, string Message, string RecaptchaToken) : IRequest<ContactMeResponse>;
