namespace Ex2_Logging_Service
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
                    LogToFile(message);
                    break;
                case enLoggingType.ToDatabase:
                    LogToDatabase(message);
                    break;
                case enLoggingType.ToEventLog:
                    LogToEventLog(message);
                    break;

            }
        }

        private void LogToFile(string message)
        {
            Console.WriteLine($"Logging to file: [{DateTime.Now}] / {message}");
        }
        private void LogToDatabase(string message)
        {
            Console.WriteLine($"Logging to database: [{DateTime.Now}] / {message}");
        }
        private void LogToEventLog(string message)
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
