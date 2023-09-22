using Bogus;
using ecommerce.Domain.Entities.Brand;
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
            Brand.RuleFor(x => x.Id, new BrandId(Guid.NewGuid()));
            Brand.RuleFor(x => x.Name, x => x.Company.CompanyName());
            Brand.RuleFor(x => x.Url, x => x.Image.PicsumUrl());
            Brand.RuleFor(x => x.ResizedUrl, x => x.Image.PicsumUrl());
            Brand.RuleFor(x => x.Hash, x => x.Random.AlphaNumeric(10));

            return Brand;
        }
    }
}
