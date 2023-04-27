namespace SchoolAdersonDeMenezes.Infraestructure.MessageBus
{
    public interface IMessageBusClient
    {
        void Publish(object message, string routingkey, string exchange);
    }
}
