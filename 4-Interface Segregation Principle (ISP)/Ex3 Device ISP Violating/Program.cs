public interface IDevice
{
    void MakeCall();
    void SendEmail();
    void BrowseInternet();
    void TakePhoto();
    void UseGPS();

}

public class SmartPhone : IDevice
{
    public void MakeCall()
    {
        Console.WriteLine("Making a call...");
    }
    public void SendEmail()
    {
        Console.WriteLine("Sending an email...");
    }
    public void BrowseInternet()
    {
        Console.WriteLine("Browsing the internet...");
    }
    public void TakePhoto()
    {
        Console.WriteLine("Taking a photo...");
    }
    public void UseGPS()
    {
        Console.WriteLine("Using GPS navigation...");
    }
}
public class BasicPhone : IDevice
{
    public void MakeCall()
    {
        Console.WriteLine("Making a call...");
    }
    public void SendEmail()
    {
        throw new NotImplementedException();
    }
    public void BrowseInternet()
    {
        throw new NotImplementedException();
    }
    public void TakePhoto()
    {
        throw new NotImplementedException();
    }
    public void UseGPS()
    {
        throw new NotImplementedException();
    }
}
public class Computer : IDevice
{
    public void MakeCall()
    {
        throw new NotImplementedException();
    }
    public void SendEmail()
    {
        Console.WriteLine("Sending an email...");
    }
    public void BrowseInternet()
    {
        Console.WriteLine("Browsing the internet...");
    }
    public void TakePhoto()
    {
        throw new NotImplementedException();
    }
    public void UseGPS()
    {
        throw new NotImplementedException();
    }
}
internal class Program
{
    static void Main(string[] args)
    {
        IDevice smartPhone = new SmartPhone();
        smartPhone.MakeCall();
        smartPhone.TakePhoto();
        smartPhone.BrowseInternet();
        smartPhone.SendEmail();
        smartPhone.UseGPS();

        Console.WriteLine();

        IDevice basicPhone = new BasicPhone();
        basicPhone.MakeCall();
        //basicPhone.BrowseInternet(); // This will throw NotImplementedException
        //basicPhone.TakePhoto(); // This will throw NotImplementedException

        Console.WriteLine();

        IDevice computer = new Computer();
        computer.SendEmail();
        computer.BrowseInternet();
        //computer.TakePhoto(); // This will throw NotImplementedException

    }
}
