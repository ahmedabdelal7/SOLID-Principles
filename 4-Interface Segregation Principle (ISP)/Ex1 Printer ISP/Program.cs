public interface IPrint
{
    void Print(string document);
}
public interface IScan
{
    void Scan();
}
public interface IFax
{
    void Fax();
}
public interface ICopy
{
    void Copy();
}

public class SimplePrinter : IPrint
{
    public void Print(string document)
    {
        Console.WriteLine("Printing... {0}", document);
    }
}

public class AdvancedPrinter : IPrint, IScan, IFax, ICopy
{
    public void Print(string document)
    {
        Console.WriteLine("Printing... {0}", document);
    }
    public void Scan()
    {
        Console.WriteLine("Scanning...");
    }
    public void Fax()
    {
        Console.WriteLine("Faxing...");
    }
    public void Copy()
    {
        Console.WriteLine("Copying...");
    }
}
internal class Program
{
    static void Main(string[] args)
    {
        SimplePrinter simplePrinter = new SimplePrinter();
        simplePrinter.Print("Document 1");


        AdvancedPrinter advancedPrinter = new AdvancedPrinter();
        advancedPrinter.Print("Document 2");
        advancedPrinter.Scan();
        advancedPrinter.Fax();
        advancedPrinter.Copy();

    }
}
