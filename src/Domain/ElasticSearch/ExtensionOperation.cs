using ecommerce.Domain.Base.ValueObject;
using ecommerce.Domain.Entities.Brand;
using ecommerce_shared.Enums;
using ecommerce_shared.Exceptions;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tables.Base.Entity;

namespace ecommerce.Domain.ElasticSearch
{
    public static class ExtensionOperation
    {

        public static void AddEntity<T>(this IElasticClient ElasticClient, T entity, ElasticSearchIndexName name) where T : class
        {

            var result = ElasticClient.Index<T>(entity, i => i.Index(name.ToString()));

            if (!result.IsValid || result.ServerError != null)
            {

                throw new ErrorElasticSearch(result.ServerError.ToString());

            }

        }

        public static void UpdateEntity<T,Y>(this IElasticClient ElasticClient, T entity, ElasticSearchIndexName name) where Y : StronglyTypeId where T : BaseEntity<Y>
        {


            var result = ElasticClient.Update<T>(entity.Id.Value, d => d
            .Index(name.ToString())
            .Doc(entity));
            if (!result.IsValid || result.ServerError != null)
            {

                throw new ErrorElasticSearch(result.ServerError.ToString());
            }
        }


        public static void DeleteEntity<T>(this IElasticClient ElasticClient, Guid entityId, ElasticSearchIndexName name) where T : class
        {

            var Result = ElasticClient.Delete<T>(entityId, d => d
            .Index(name.ToString())
            );

            if (!Result.IsValid || Result.ServerError != null)
            {

                throw new ErrorElasticSearch(Result.ServerError.ToString());

            }


        }


    }
}
