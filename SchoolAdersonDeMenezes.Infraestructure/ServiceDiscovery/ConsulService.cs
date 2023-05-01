using Consul;
using SchoolAdersonDeMenezes.Infraestructure.Exceptions;

namespace SchoolAdersonDeMenezes.Infraestructure.ServiceDiscovery
{
    public class ConsulService : IServiceDiscovery
    {
        private readonly IConsulClient _consulClient;
        public ConsulService(IConsulClient consulClient)
        {
            _consulClient = consulClient;
        }
        public async Task<Uri> GetServiceUri(string serviceName, string requestUrl)
        {
            var getAllServiceRegisted = await _consulClient.Agent.Services();

            try
            {
                var servicesFilted = getAllServiceRegisted.Response?
                    .Where(x => x.Value.Service.Equals(serviceName, StringComparison.OrdinalIgnoreCase))
                    .Select(x => x.Value)
                    .ToList();

                var service = servicesFilted.First();


                Console.WriteLine($"Service Address: {service.Address}");


                var uri = $"http://{service.Address}:{service.Port}/{requestUrl}";

                return new Uri(uri);

            }
            catch (Exception ex)
            {
                throw new ServiceNotFoundException(serviceName, ex.Message);
            }
        }
    }
}
