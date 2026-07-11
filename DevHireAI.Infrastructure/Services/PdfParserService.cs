using DevHireAI.Application.Interfaces.Services;
using UglyToad.PdfPig;

namespace DevHireAI.Infrastructure.Services;

public class PdfParserService : IPdfParserService
{
    public async Task<string> ExtractTextAsync(Stream pdfStream)
    {
        using var document = PdfDocument.Open(pdfStream);

        var text = string.Empty;

        foreach (var page in document.GetPages())
        {
            text += page.Text + Environment.NewLine;
        }

        return await Task.FromResult(text);
    }
}