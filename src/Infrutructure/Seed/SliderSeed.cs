using ecommerce.Domain.Entities.Slider;
using ecommerce.infrutructure.Data;
using ecommerce_shared.Enums;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.infrutructure.Seed
{
    public static class SliderSeed
    {

        public static async Task seedData(ApplicationDbContext context, IElasticClient ElasticClient)
        {

            //if(!context.Sliders.Any()) {


            //    List<Slider> Sliders = SliderFaker
            //        .GetSliderFaker()
            //        .Generate(5)
            //        .DistinctBy(x=>x.Rank)
            //        .ToList();

            //    context.AddRange(Sliders);
            //    context.SaveChanges();
            //    ElasticClient.IndexMany(Sliders, ElasticSearchIndexName.slider.ToString());


            //}





        }
    }
}
