using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Driver;
using SchoolAdersonDeMenezes.Domain.Repositories;
using SchoolAdersonDeMenezes.Infraestructure.Persistence;

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


    }
}
