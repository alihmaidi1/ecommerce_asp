using ecommerce_shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tables.Base.Entity;

namespace ecommerce.Repository.ElasticSearch
{
    public interface IElasticSearch
    {


        public void Add<T>(T entity,ElasticSearchIndexName name) where T : class;


        public void Update<T>(T entity, ElasticSearchIndexName name) where T : BaseEntity;
        public void Delete<T>(T entity, ElasticSearchIndexName name) where T : BaseEntity;


    }
}
