namespace CMSAppOA.Contract.Services;

public interface INotificationService
{
    Task SendEmailNotification(string message, int customerId);
    Task SendSmsNotification(string message, int customerId);
    
}
