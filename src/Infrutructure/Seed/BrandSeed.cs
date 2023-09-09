using ecommerce.Domain.Entities;
using ecommerce.infrutructure.Data;
using Nest;
namespace ecommerce.infrutructure.seed
{
    public static class BrandSeed
    {

        public static async Task seedData(ApplicationDbContext context,IElasticClient ElasticClient)
        {           
            List<Brand> brands=BrandFaker.GetBrandFaker().Generate(5);
            context.AddRange(brands);            
            context.SaveChanges();
            ElasticClient.IndexMany(brands, "brand");


        }
    }
}
