public class LoggingService
{
    private ILoggingService _LoggingService;

    public LoggingService(ILoggingService loggingService)
    {
        _LoggingService = loggingService;
    }
    public void Log(string message)
    {
        _LoggingService.Log(message);
    }

}

//Interface for Logging Service
public interface ILoggingService
{
    public void Log(string message);
}

public class FileLoggingService : ILoggingService
{
    // Method to log to file
    public void Log(string message)
    {
        Console.WriteLine($"\nLog to file: {message}");
    }
}

public class EventLogService : ILoggingService
{
    // Method to log to EventLog
    public void Log(string message)
    {
        Console.WriteLine($"\nLog to Event Log: {message}");
    }
}

public class DatabaseLoggingService : ILoggingService
{

    // Method to log to database
    public void Log(string message)
    {
        Console.WriteLine($"\nLog to Database: {message}");
    }
}
public class ConsoleLoggingService : ILoggingService
{
    // Method to log to console
    public void Log(string message)
    {
        Console.WriteLine($"\nLog to Console: {message}");
    }
}


class Program
{
    static void Main()
    {

        LoggingService LoggingService;

        // Log to File
        LoggingService = new LoggingService(new FileLoggingService());
        LoggingService.Log("Error Occured line xxx.");

        // Log to Event Log
        LoggingService = new LoggingService(new EventLogService());
        LoggingService.Log("Error Occured line xxx.");

        // Log to Database
        LoggingService = new LoggingService(new DatabaseLoggingService());
        LoggingService.Log("Error Occured line xxx.");

        // Log to Console
        LoggingService = new LoggingService(new ConsoleLoggingService());
        LoggingService.Log("Error Occured line xxx.");

        Console.ReadKey();

    }

}
