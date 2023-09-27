using ecommerce.Domain.Entities.Brand;
using ecommerce.Domain.Entities.Slider;
using ecommerce_shared.Enums;
using ecommerce.Domain.Entities.BrandEntities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;

namespace ecommerce.Domain.ElasticSearch
{
    public static  class ElasticSearchExtension
    {

        public static IServiceCollection AddElasticSearch(this IServiceCollection services, IConfiguration configuration)
        {

            var settings = GetSetting(configuration);
            var client=new ElasticClient(settings);
            client = CreateIndexes(client);
            services.AddSingleton<IElasticClient>(client);
            return services;

        }

        private static ConnectionSettings GetSetting(IConfiguration configuration)
        {

            string url = configuration["elasticsearchConfig:url"];
            string index = configuration["elasticsearchConfig:index"];
            var settings = new ConnectionSettings(new Uri(url))
                         .PrettyJson()
                         .DefaultIndex(index);
            return settings;

        }

        private static ElasticClient CreateIndexes(ElasticClient Client)
        {

            Client.Indices
                  .Create(nameof(ElasticSearchIndexName.brand),
                  e => e.Map<Brand>(m => m.AutoMap<Brand>()));

            Client.Indices
                  .Create(nameof(ElasticSearchIndexName.slider),
                  e => e.Map<Slider>(m => m.AutoMap<Slider>()));

            return Client;  

        }


        


    }
}
