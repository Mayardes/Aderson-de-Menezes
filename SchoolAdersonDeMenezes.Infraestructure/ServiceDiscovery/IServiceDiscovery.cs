namespace SchoolAdersonDeMenezes.Infraestructure.ServiceDiscovery
{
    /// <summary>
    /// How to get a service from Service Discovery by Consul.
    /// </summary>
    public interface IServiceDiscovery
    {
        Task<Uri> GetServiceUri(string serviceName, string requestUrl);
    }
}
