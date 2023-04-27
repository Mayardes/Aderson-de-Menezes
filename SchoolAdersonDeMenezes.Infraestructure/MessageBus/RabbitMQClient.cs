using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RabbitMQ.Client;
using System.Text;

namespace SchoolAdersonDeMenezes.Infraestructure.MessageBus
{
    public class RabbitMQClient : IMessageBusClient
    {
        private readonly IConnection _connection;
        public RabbitMQClient(ProducerConnection producerConnection)
        {
            _connection = producerConnection.Connection;
        }
        public void Publish(object message, string routingkey, string exchange)
        {
           var settings = new JsonSerializerSettings()
           {
               NullValueHandling = NullValueHandling.Ignore,
               ContractResolver = new CamelCasePropertyNamesContractResolver(),
           };

           var channel = _connection.CreateModel();
           
           var payload = JsonConvert.SerializeObject(message);

           var body = Encoding.UTF8.GetBytes(payload);

           channel.BasicPublish(exchange, routingkey, null, body);
        }
    }
}
