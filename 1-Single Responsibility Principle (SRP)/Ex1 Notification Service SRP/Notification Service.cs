using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

public class NotificationService
{
    public enum enNotificationType
    {
        Email,
        SMS,
        Fax
    }

    public void SendNotification(string to, string message, enNotificationType NotificationType)
    {
        switch (NotificationType)
        {
            case enNotificationType.Email:
                EmailService.SendEmail(to, message);
                break;
            case enNotificationType.SMS:
                SMSService.SendSMS(to, message);
                break;
            case enNotificationType.Fax:
                FaxService.SendFax(to, message);
                break;
            default:
                throw new ArgumentException("Invalid notification type");
        }
    }

}


public class EmailService
{
    public static void SendEmail(string to, string message)
    {
        Console.WriteLine($"\nSending Email to {to} with message: {message}");
    }
}
public class SMSService
{
    public static void SendSMS(string to, string message)
    {
        Console.WriteLine($"\nSending SMS to {to} with message: {message}");
    }
}

public class FaxService
{
    public static void SendFax(string to, string message)
    {
        Console.WriteLine($"\nSending FAX to {to} with message: {message}");
    }
}