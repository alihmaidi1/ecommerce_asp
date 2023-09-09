using Bogus;
using ecommerce.Domain.ElasticSearch;
using ecommerce.Domain.Entities;
using ecommerce.infrutructure.Data;
using EFCore.BulkExtensions;
using Nest;
using Org.BouncyCastle.Math.EC.Rfc7748;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.infrutructure.seed
{
    public static class BrandSeed
    {

        public static async Task seedData(ApplicationDbContext context,IElasticClient ElasticClient)
        {
           
            List<Brand> brands=BrandFaker.GetBrandFaker().Generate(5);
            context.AddRange(brands);            
            context.SaveChanges();
            foreach(Brand brand in brands)
            {
                ElasticClient.AddEntity(brand,ecommerce_shared.Enums.ElasticSearchIndexName.brand);
                
            }
           



        }
    }
}
