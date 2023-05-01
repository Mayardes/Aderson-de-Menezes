using SchoolAdersonDeMenezes.Infraestructure.ServiceDiscovery;

namespace SchoolAdersonDeMenezes.Infraestructure.ServiceIntegration
{

    public class GetNotificationServiceIntegration : IGetNotificationServiceIntegration
    {
        public readonly IHttpClientFactory _httpClientFactory;
        private readonly IServiceDiscovery _serviceDiscovery;

        public GetNotificationServiceIntegration(IHttpClientFactory httpClientFactory, IServiceDiscovery serviceDiscovery)
        {
            _httpClientFactory = httpClientFactory;
            _serviceDiscovery = serviceDiscovery;
        }
        public async Task<string> SendEmailNotification(string email)
        {

            var notificationUri = await _serviceDiscovery
                .GetServiceUri("NotificationServices", $"/v1/notification/enviarEmail/{email}");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, notificationUri);

            using (var httpClient = _httpClientFactory.CreateClient())
            {
                var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();

                    StreamReader sr = new StreamReader(contentStream);

                    string text = sr.ReadToEnd();
                    await Console.Out.WriteLineAsync($"Result is {text}");

                    return text;
                }
            }

            return string.Empty;
        }
    }
}
