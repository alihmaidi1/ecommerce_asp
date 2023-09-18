using Bogus;
using ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.infrutructure.Data
{
    public static class SliderFaker
    {
        public static Faker<Slider> GetSliderFaker()
        {

            var Slider = new Faker<Slider>();
            Slider.RuleFor(x => x.Id, Guid.NewGuid);
            Slider.RuleFor(x => x.Rank, x =>x.Random.Int(1,2045400994));
            Slider.RuleFor(x => x.Url, x => x.Image.PicsumUrl());
            Slider.RuleFor(x => x.ResizedUrl, x => x.Image.PicsumUrl());
            Slider.RuleFor(x => x.Hash, x => x.Random.AlphaNumeric(10));

            return Slider;
        }
    }
}
