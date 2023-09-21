using Amazon.S3.Model;
using ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.infrutructure.Seed
{
    public static class CurrencySeed
    {

        public static async Task seedData(ApplicationDbContext context)
        {


            if(!context.Currencies.Any())
            {

                List<Currency> Currencies = new List<Currency>
            {

                new Currency
                {

                    Name="Syria",
                    Code="SYP",
                    Status=true

                },


                new Currency
                {

                    Name="Euro",
                    Code="EUR",
                    Status=true

                }


            };

                context.Currencies.AddRange(Currencies);
                context.SaveChanges();



            }



        }
    }
}
