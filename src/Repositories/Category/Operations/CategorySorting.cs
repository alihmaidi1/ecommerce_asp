using System.Linq.Expressions;

namespace Repositories.Category.Operations;

public class CategorySorting
{
    
    public static List<string> OrderBy = new List<string>()
    {
        "Name",
        "Status",
        "Rank",
    };
    
    public static Func<string, Expression<Func<ecommerce.Domain.Entities.Category, object>>> switchOrdering= key
            
        =>key switch
        {
            "Name" => x => x.Name,
            "Status"=>x=>x.Status,
            "Rank"=>x=>x.Rank,
            _ => x => x.DateCreated
            
            
        };


    
}