namespace backend.Application.Portfolios.Commands.VerifyAndDownloadCv;
using MediatR;

public record VerifyAndDownloadCvCommand(string SecretCode) : IRequest<VerifyAndDownloadCvResponse>;
