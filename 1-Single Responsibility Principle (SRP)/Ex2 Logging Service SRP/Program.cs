namespace Ex2_Logging_Service_SRP
{
    public class LoggingService
    {
        public enum enLoggingType
        {
            ToFile, ToDatabase, ToEventLog
        }
        public void Log(string message, enLoggingType loggingType)
        {
            switch (loggingType)
            {
                case enLoggingType.ToFile:
                    LogToFileService.Log(message);
                    break;
                case enLoggingType.ToDatabase:
                    LogToDatabaseService.Log(message);
                    break;
                case enLoggingType.ToEventLog:
                    LogToEventLogService.Log(message);
                    break;

            }
        }
    }
    public class LogToFileService
    {
        public static void Log(string message)
        {
            Console.WriteLine($"Logging to file: [{DateTime.Now}] / {message}");
        }
    }
    public class LogToDatabaseService
    {
        public static void Log(string message)
        {
            Console.WriteLine($"Logging to database: [{DateTime.Now}] / {message}");
        }
    }
    public class LogToEventLogService
    {
        public static void Log(string message)
        {
            Console.WriteLine($"Logging to event log: [{DateTime.Now}] / {message}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //Test the LoggingService
            LoggingService loggingService = new LoggingService();
            loggingService.Log("Logging to file..", LoggingService.enLoggingType.ToFile);
            loggingService.Log("Logging to database..", LoggingService.enLoggingType.ToDatabase);
            loggingService.Log("Logging to event log..", LoggingService.enLoggingType.ToEventLog);
        }
    }
}
