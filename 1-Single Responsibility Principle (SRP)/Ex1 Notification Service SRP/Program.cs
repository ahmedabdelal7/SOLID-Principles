namespace Ex1_Notification_Service_SRP
{
    internal class Program
    {
        static void Main(string[] args)
        {

            NotificationService notificationService = new NotificationService();

            notificationService.SendNotification("john.doe@example.com", "Hello, Email!",
                NotificationService.enNotificationType.Email);

            notificationService.SendNotification("1234567890", "Hello, SMS!",
                NotificationService.enNotificationType.SMS);

            notificationService.SendNotification("9876543210", "Hello, Fax!",
                NotificationService.enNotificationType.Fax);
        }
    }
}
