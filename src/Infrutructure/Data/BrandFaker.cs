using Bogus;
using ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.infrutructure.Data
{
    public static class BrandFaker
    {

        public static Faker<Brand> GetBrandFaker()
        {

            var Brand = new Faker<Brand>();
            Brand.RuleFor(x => x.Id, Guid.NewGuid);
            Brand.RuleFor(x => x.Name, x => x.Company.CompanyName());
            Brand.RuleFor(x => x.Url, x => x.Image.Business(300,300,true,true));
            Brand.RuleFor(x => x.ResizedUrl, x => x.Image.Transport(400,400,false,false));
            Brand.RuleFor(x => x.Hash, x => x.Random.AlphaNumeric(10));

            return Brand;
        }
    }
}
