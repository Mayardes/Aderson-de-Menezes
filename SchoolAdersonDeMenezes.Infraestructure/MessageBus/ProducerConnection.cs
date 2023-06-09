﻿using RabbitMQ.Client;

namespace SchoolAdersonDeMenezes.Infraestructure.MessageBus
{
    public class ProducerConnection
    {
        public IConnection Connection { get; private set; }

        public ProducerConnection(IConnection connection)
        {
            Connection = connection;
        }
    }
}
