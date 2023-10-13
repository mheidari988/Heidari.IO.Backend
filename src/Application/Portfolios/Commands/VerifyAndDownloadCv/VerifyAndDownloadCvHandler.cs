namespace backend.Application.Portfolios.Commands.VerifyAndDownloadCv;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

public class VerifyAndDownloadCvHandler : IRequestHandler<VerifyAndDownloadCvCommand, VerifyAndDownloadCvResponse>
{
    private readonly IHttpClientFactory httpClientFactory;

    public VerifyAndDownloadCvHandler(IHttpClientFactory httpClientFactory)
    {
        this.httpClientFactory = httpClientFactory;
    }

    public async Task<VerifyAndDownloadCvResponse> Handle(VerifyAndDownloadCvCommand request, CancellationToken cancellationToken)
    {
        // TODO: Get from Db
        var downloadUrl = "/heidari-io-container/Resume.pdf";

        // TODO: Move to Db and confirm the code is valid
        var secretCode = "qwe123";

        if (request.SecretCode != secretCode)
        {
            throw new ValidationException("Invalid secret code");
        }

        var httpClient = this.httpClientFactory.CreateClient("azure-blob-storage");
        var stream = await httpClient.GetStreamAsync(downloadUrl, cancellationToken);

        VerifyAndDownloadCvResponse response = new(
            CvFileStream: stream,
            CvFileMimeType: "application/pdf",
            CvFileName: "Resume.pdf"
        );

        return response;
    }
}
