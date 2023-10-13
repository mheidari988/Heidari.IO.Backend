namespace backend.Application.Portfolios.Commands.VerifyAndDownloadCv;
public record VerifyAndDownloadCvResponse(Stream CvFileStream, string CvFileMimeType, string CvFileName);
