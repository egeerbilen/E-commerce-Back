using Entity.Model;

namespace Entity.Repositories
{
    public interface IUserBasketRepository
    {
        Task<UserBaskets> CreateUserBasketProductsAsync(UserBaskets userBasketssProducts);
        Task<bool> DeleteUserBasketProductsAsync(int userId, int productId);
    }
}
