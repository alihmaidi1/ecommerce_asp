using Bogus;
using ecommerce.Domain.Entities;
using ecommerce.Domain.Entities.BrandEntities;

namespace ecommerce.infrutructure.Data;

public class CategoryFaker
{

    public static Faker<Category> GetCategoryFaker()
    {

        var Category = new Faker<Category>();
        Category.RuleFor(x => x.Id, Guid.NewGuid);
        Category.RuleFor(x => x.Name, x => x.Commerce.Categories(2).First());
        Category.RuleFor(x => x.Rank, x => x.Random.Int(1, 2045400994));
        Category.RuleFor(x => x.Description, x => x.Random.Words(100));
        Category.RuleFor(x => x.Status, true);
        Category.RuleFor(x => x.Meta_Description, x => x.Random.Words(100));
        Category.RuleFor(x => x.Meta_Title, x => x.Random.Word().ToString());
        return Category;

    }
}