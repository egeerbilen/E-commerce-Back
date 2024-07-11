namespace Entity.Repositories
{
    // ekleme çıkarma yazılacak sadece zaten update get bu id zaten gerekli değil
    public interface IUserRoleRepository
    {
        Task<bool> AddUserRoleAsync(int basketId, int productId);
        Task<bool> RemoveUserRoleAsync(int basketId, int productId);
    }
}
