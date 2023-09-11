﻿using ecommerce.Domain.Entities;
using ecommerce_shared.Enums;
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


            return Client;  

        }


        


    }
}