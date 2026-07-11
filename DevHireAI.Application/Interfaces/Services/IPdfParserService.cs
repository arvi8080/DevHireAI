namespace DevHireAI.Application.Interfaces.Services;

public interface IPdfParserService
{
    Task<string> ExtractTextAsync(Stream pdfStream);
}