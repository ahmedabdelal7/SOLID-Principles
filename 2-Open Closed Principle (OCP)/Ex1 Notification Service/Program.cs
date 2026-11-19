namespace Ex1_Notification_Service
{
    public class  NotificationService
    {
        public enum enNotificationType
        {
            Email,
            SMS,
            Fax,
            Telegram,
            Whatsapp
        }
        public void SendNotification(string to, string message, enNotificationType type)
        {
            if(type == enNotificationType.Email)
            {
                EmailService.Send(to, message);
            }
            else if (type == enNotificationType.SMS)
            {
                SMSService.Send(to, message);
            }
            else if (type == enNotificationType.Fax)
            {
                FaxService.Send(to, message);
            }
            else if (type == enNotificationType.Telegram)
            {
                TelegramService.Send(to, message);
            }
            else if (type == enNotificationType.Whatsapp)
            {
                WhatsappService.Send(to, message);
            }
        }

     
    }

    public class  EmailService
    {
        public static void Send(string to, string message)
        {
            Console.WriteLine($"Sending Email to {to}: {message}");
        }
    }
    public class SMSService
    {
        public static void Send(string to, string message)
        {
            Console.WriteLine($"Sending SMS to {to}: {message}");
        }
    }
    public class FaxService
    {
        public static void Send(string to, string message)
        {
            Console.WriteLine($"Sending Fax to {to}: {message}");
        }
    }
    public class TelegramService
    {
        public static void Send(string to, string message)
        {
            Console.WriteLine($"Sending Telegram to {to}: {message}");
        }
    }
    public class  WhatsappService
    {
        public static void Send(string to, string message)
        {
            Console.WriteLine($"Sending Whatsapp to {to}: {message}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var notificationService = new NotificationService();
            notificationService.SendNotification("user@example.com", "Hello, World!", NotificationService.enNotificationType.Email);
            notificationService.SendNotification("+1234567890", "Hello, World!", NotificationService.enNotificationType.SMS);
            notificationService.SendNotification("+1234567890", "Hello, World!", NotificationService.enNotificationType.Fax);
            notificationService.SendNotification("@username", "Hello, World!", NotificationService.enNotificationType.Telegram);
            notificationService.SendNotification("+1234567890", "Hello, World!", NotificationService.enNotificationType.Whatsapp);



        }
    }
}
