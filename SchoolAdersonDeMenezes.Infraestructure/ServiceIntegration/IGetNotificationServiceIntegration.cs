namespace SchoolAdersonDeMenezes.Infraestructure.ServiceIntegration
{
    public interface IGetNotificationServiceIntegration
    {
        Task<string> SendEmailNotification(string email);
    }
}
