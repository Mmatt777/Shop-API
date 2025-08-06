namespace Shop.Infrastructure.Authorization.Services
{
    public interface IShopAuthorizationService
    {
        bool IsAuthorize(ResourceOperation resourceOperation);
    }
}