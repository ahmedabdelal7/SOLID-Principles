
public interface ICallDevice
{
    void MakeCall();
}
public interface IEmailDevice
{
    void SendEmail();
}
public interface IInternetDevice
{
    void BrowseInternet();
}
public interface IPhotoDevice
{
    void TakePhoto();
}
public interface IGPSDevice
{
    void UseGPS();
}

public class SmartPhone : ICallDevice, IEmailDevice, IInternetDevice, IPhotoDevice, IGPSDevice
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
public class BasicPhone : ICallDevice
{
    public void MakeCall()
    {
        Console.WriteLine("Making a call...");
    }
}
public class Computer : IInternetDevice, IEmailDevice
{
    public void SendEmail()
    {
        Console.WriteLine("Sending an email...");
    }
    public void BrowseInternet()
    {
        Console.WriteLine("Browsing the internet...");
    }
}
public  class Camera : IPhotoDevice
{
    public void TakePhoto()
    {
        Console.WriteLine("Taking a photo...");
    }
}

public class AdvancedCamera : IPhotoDevice , IEmailDevice
{
    public void TakePhoto()
    {
        Console.WriteLine("Taking a photo...");
    }
    public void SendEmail()
    {
        Console.WriteLine("Sending an email...");
    }
}
internal class Program
{
    static void Main(string[] args)
    {
        SmartPhone smartPhone = new SmartPhone();
        smartPhone.MakeCall();
        smartPhone.TakePhoto();
        smartPhone.BrowseInternet();
        smartPhone.SendEmail();
        smartPhone.UseGPS();

        Console.WriteLine();

        BasicPhone basicPhone = new BasicPhone();
        basicPhone.MakeCall();

        Console.WriteLine();

        Computer computer = new Computer();
        computer.SendEmail();
        computer.BrowseInternet();

    }
}
