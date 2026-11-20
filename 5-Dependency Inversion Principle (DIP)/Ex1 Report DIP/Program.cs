/*
Dependency Inversion Principle(DIP) in C#.
The Dependency Inversion Principle states that high-level modules should not depend on low-level modules.
Both should depend on abstractions.
*/

/*
In this example, we have an interface `IReportGenerator` that defines the contract for generating reports.
Different report generators implement this interface, allowing the `ReportGenerator` class to depend on the abstraction rather than concrete implementations.
*/

// This code applied-> SRP, OCP, DIP + DI design pattern
public interface IReportGenerator
{
    void GenerateReport();
}
public class PDFReportGenerator:IReportGenerator
{
    public void GenerateReport()
    {
        Console.WriteLine("Generating PDF Report...");
    }
}

public class CrystalReportGenerator : IReportGenerator
{
    public void GenerateReport()
    {
        Console.WriteLine("Generating Crystal Report...");
    }
}
public class  WordReportGenerator : IReportGenerator
{
    public void GenerateReport()
    {
        Console.WriteLine("Generating Word Report...");
    }

}
public class ExcelReportGenerator : IReportGenerator
{
    public void GenerateReport()
    {
        Console.WriteLine("Generating Excel Report...");
    }

}
public class ReportGenerator
{

    private IReportGenerator _ReportGenerator;
    public ReportGenerator(IReportGenerator reportGenerator)
    {
        _ReportGenerator = reportGenerator;
    }

    public void GenerateReport()
    {
        _ReportGenerator.GenerateReport();
    }
}

internal class Program
{
    static void Main(string[] args)
    {        
        ReportGenerator reportGenerator = new ReportGenerator(new PDFReportGenerator());
        reportGenerator.GenerateReport();

        reportGenerator = new ReportGenerator(new CrystalReportGenerator());
        reportGenerator.GenerateReport();

        reportGenerator = new ReportGenerator(new WordReportGenerator());
        reportGenerator.GenerateReport();

        reportGenerator = new ReportGenerator(new ExcelReportGenerator());
        reportGenerator.GenerateReport();
    }
}
