using ecommerce.Domain.Base.ValueObject;

namespace ecommerce.Domain.Entities.BrandEntities;

public class BrandId:StronglyTypeId
{

    public BrandId(Guid Value) : base(Value)
    {


        

    }

    public static implicit operator Guid(BrandId StronglyId) => StronglyId.Value;
    public static implicit operator BrandId(Guid value) => new BrandId(value);


    
}