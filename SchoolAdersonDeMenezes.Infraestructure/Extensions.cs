using Amazon.Util.Internal.PlatformServices;
using Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Bson;
using MongoDB.Driver;
using RabbitMQ.Client;
using SchoolAdersonDeMenezes.Domain.Repositories;
using SchoolAdersonDeMenezes.Infraestructure.MessageBus;
using SchoolAdersonDeMenezes.Infraestructure.Persistence;
using SchoolAdersonDeMenezes.Infraestructure.ServiceDiscovery;
using SchoolAdersonDeMenezes.Infraestructure.ServiceIntegration;

namespace SchoolAdersonDeMenezes.Infraestructure
{
    public static class Extensions
    {
        public static IServiceCollection AddMongo (this IServiceCollection services)
        {
            services.AddSingleton(sp =>
            {
                var options = sp.GetService<IConfiguration>();

                var mongoDoConfiguration = new MongoDbOptions();

                options.GetSection("Mongo").Bind(mongoDoConfiguration);

                return mongoDoConfiguration;
            });

            services.AddScoped<IMongoClient>(sp =>
            {
                var options = sp.GetService<MongoDbOptions>();
                
                return new MongoClient(options.ConnectionString);
            });

            services.AddScoped(sp =>
            {
                BsonDefaults.GuidRepresentation = GuidRepresentation.Standard;

                var option = sp.GetService<MongoDbOptions>();
                var mongoOption = sp.GetService<IMongoClient>();

                return mongoOption.GetDatabase(option.Database);
            });

            return services;
        }

        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<ISchoolRepository, SchoolRepository>();

            return services;
        }

        public static IServiceCollection AddMessageBus(this IServiceCollection services)
        {
            var connectionFactory = new ConnectionFactory()
            {
                HostName = "localhost"
            };

            var connection = connectionFactory.CreateConnection("school-service-producer");

            services.AddSingleton(new ProducerConnection(connection));

            services.AddSingleton<IMessageBusClient, RabbitMQClient>();

            return services;
        }

        public static IServiceCollection AddConsulConfig(this IServiceCollection services)
        {

            services.AddSingleton<IConsulClient, ConsulClient>(sp => new ConsulClient(consulConfig =>
            {
                var config = sp.GetService<IConfiguration>();

                var address = config.GetValue<string>("Consul:Host");

                consulConfig.Address = new Uri(address);

            }));

            services.AddTransient<IServiceDiscovery, ConsulService>();

            return services;
        }
        public static IApplicationBuilder UseConsul(this IApplicationBuilder app)
        {
            var consulClient = app.ApplicationServices.GetRequiredService<IConsulClient>();
            var lifeTime = app.ApplicationServices.GetRequiredService<IHostApplicationLifetime>();

            var registration = new AgentServiceRegistration
            {
                ID = $"school-service-{Guid.NewGuid()}",
                Name = "SchoolService",
                Address = "localhost",
                Port = 5003
            };

            consulClient.Agent.ServiceDeregister(registration.ID).ConfigureAwait(true);
            consulClient.Agent.ServiceRegister(registration).ConfigureAwait(true);

            Console.WriteLine($"Service registed in Consul: {registration.Name}");

            lifeTime.ApplicationStopped.Register(() =>
            {
                consulClient.Agent.ServiceDeregister(registration.ID).ConfigureAwait(true);
                Console.WriteLine($"Service deregisted in Consul: {registration.Name}");
            });

            return app;
        }

        public static IServiceCollection AddNotificationServiceIntegration(this IServiceCollection services)
        {
            services.AddScoped<IGetNotificationServiceIntegration, GetNotificationServiceIntegration>();
            return services;
        }
    }
}
