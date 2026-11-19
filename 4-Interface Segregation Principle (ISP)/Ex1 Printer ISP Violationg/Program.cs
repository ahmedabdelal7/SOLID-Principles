public interface IPrinter
{
    void Print(string document);
    void Scan();
    void Fax();
    void Copy();
}

public class SimplePrinter : IPrinter
{
    public void Print(string document)
    {
        Console.WriteLine("Printing... {0}", document);
    }
    public void Scan()
    {
        throw new NotImplementedException("Scan functionality is not supported.");
    }
    public void Fax()
    {
        throw new NotImplementedException("Fax functionality is not supported.");
    }
    public void Copy()
    {
        throw new NotImplementedException("Copy functionality is not supported.");
    }
}

public class AdvancedPrinter : IPrinter
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
        IPrinter simplePrinter = new SimplePrinter();
        simplePrinter.Print("Document 1");
        //simplePrinter.Scan(); // This will throw NotImplementedException
        //simplePrinter.Fax();  // This will throw NotImplementedException
        //simplePrinter.Copy(); // This will throw NotImplementedException


        IPrinter advancedPrinter = new AdvancedPrinter();
        advancedPrinter.Print("Document 2");
        advancedPrinter.Scan();
        advancedPrinter.Fax();
        advancedPrinter.Copy();


    }
}
