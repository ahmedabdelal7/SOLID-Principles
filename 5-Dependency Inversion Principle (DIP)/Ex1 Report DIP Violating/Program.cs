public class PDFReportGenerator
{
    public void GenerateReport()
    {
        Console.WriteLine("Generating PDF Report...");
    }
}

public class ReportGenerator
{
    private PDFReportGenerator _pdfReportGenerator;

    public ReportGenerator()
    {
        _pdfReportGenerator = new PDFReportGenerator();
    }

    public void GenerateReport()
    {
        _pdfReportGenerator.GenerateReport();
    }
}

internal class Program
{
    static void Main(string[] args)
    {
        ReportGenerator reportGenerator = new ReportGenerator();
        reportGenerator.GenerateReport();
    }
}
