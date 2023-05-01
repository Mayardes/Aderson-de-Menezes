namespace SchoolAdersonDeMenezes.Infraestructure.Exceptions
{
    public class ServiceNotFoundException : Exception
    {
        public ServiceNotFoundException(string service, string message): base($"SERVICE {service} NOT FOUND: {message}"){}
    }
}
