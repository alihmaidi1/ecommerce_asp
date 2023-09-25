namespace ecommerce.Domain.AppMetaData.User;

public static class CountryRouter
{
    private const string prefix = Router.Rule+Router.User+"/country" ;

    public const string GetAll = prefix + "/getall";

    public const string ActiveCity = prefix + "/{id:guid}/active";
    
}