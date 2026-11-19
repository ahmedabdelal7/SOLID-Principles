namespace Ex1_Notification_Service
{
    public class  NotificationService
    {
        private INotification _Notification;
        public NotificationService(INotification notification)
        {
            _Notification = notification;
        }
        public void SendNotification(string to, string message)
        {
            //if(type == enNotificationType.Email)
            //{
            //    EmailService.Send(to, message);
            //}
            //else if (type == enNotificationType.SMS)
            //{
            //    SMSService.Send(to, message);
            //}
            //else if (type == enNotificationType.Fax)
            //{
            //    FaxService.Send(to, message);
            //}
            //else if (type == enNotificationType.Telegram)
            //{
            //    TelegramService.Send(to, message);
            //}
            //else if (type == enNotificationType.Whatsapp)
            //{
            //    WhatsappService.Send(to, message);
            //}

            _Notification.Send(to,message);
        }

     
    }

    public interface INotification
    {
        public void Send(string to, string message);
    }
    public class  EmailService:INotification
    {
        public void Send(string to, string message)
        {
            Console.WriteLine($"Sending Email to {to}: {message}");
        }
    }
    public class SMSService:INotification
    {
        public void Send(string to, string message)
        {
            Console.WriteLine($"Sending SMS to {to}: {message}");
        }
    }
    public class FaxService:INotification
    {
        public void Send(string to, string message)
        {
            Console.WriteLine($"Sending Fax to {to}: {message}");
        }
    }
    public class TelegramService:INotification
    {
        public void Send(string to, string message)
        {
            Console.WriteLine($"Sending Telegram to {to}: {message}");
        }
    }
    public class  WhatsappService:INotification
    {
        public void Send(string to, string message)
        {
            Console.WriteLine($"Sending Whatsapp to {to}: {message}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var notificationService = new NotificationService(new EmailService());
            notificationService.SendNotification("user@example.com", "Hello, World!");

            notificationService = new NotificationService(new SMSService());
            notificationService.SendNotification("+1234567890", "Hello, World!");

            notificationService = new NotificationService(new FaxService());
            notificationService.SendNotification("user@fax.com", "Hello, World!");

            notificationService = new NotificationService(new TelegramService());
            notificationService.SendNotification("@username", "Hello, World!");

            notificationService = new NotificationService(new WhatsappService());
            notificationService.SendNotification("+1234567890", "Hello, World!");

        }
    }
}
