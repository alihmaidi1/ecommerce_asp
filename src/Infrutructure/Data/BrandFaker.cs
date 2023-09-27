using Bogus;
using ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ecommerce.Domain.Entities.BrandEntities;

namespace ecommerce.infrutructure.Data
{
    public static class BrandFaker
    {

        public static Faker<Brand> GetBrandFaker()
        {

            
            var Brand = new Faker<Brand>();
            Brand.RuleFor(x => x.Id, Guid.NewGuid);
            Brand.RuleFor(x => x.Name, x => x.Company.CompanyName());
            Brand.RuleFor(x => x.Url, x => x.Image.PicsumUrl());
            Brand.RuleFor(x => x.ResizedUrl, x => x.Image.PicsumUrl());
            Brand.RuleFor(x => x.Hash, x => "LGF5]+Yk^6#M@-5c,1J5@[or[Q6.");
            return Brand;
        }
    }
}
