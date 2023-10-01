using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ecommerce.Domain.Entities;
using ecommerce.infrutructure.Data;

namespace ecommerce.infrutructure.Seed
{
    public static class CategorySeed
    {

        public static async Task seedData(ApplicationDbContext context)
        {
            
            
            
            if (!context.Categories.Any())
            {

                List<Category> categories = CategoryFaker.GetCategoryFaker().Generate(5).DistinctBy(x=>x.Rank).DistinctBy(x=>x.Name).ToList();
                context.AddRange(categories);
                context.SaveChanges();

            }



        }
    }
}
