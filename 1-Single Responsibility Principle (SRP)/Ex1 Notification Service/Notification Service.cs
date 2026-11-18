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
                SendEmail(to, message);
                break;
            case enNotificationType.SMS:
                SendSMS(to, message);
                break;
            case enNotificationType.Fax:
                SendFax(to, message);
                break;
            default:
                throw new ArgumentException("Invalid notification type");
        }
    }

    private void SendEmail(string to, string message)
    {
        Console.WriteLine($"\nSending Email to {to} with message: {message}");
    }
    private void SendSMS(string to, string message)
    {
        Console.WriteLine($"\nSending SMS to {to} with message: {message}");
    }
    private void SendFax(string to, string message)
    {
        Console.WriteLine($"\nSending Fax to {to} with message: {message}");
    }

}

