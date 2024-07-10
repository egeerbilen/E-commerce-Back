using Core.DTOs;

namespace Entity.Repositories
{
    // ekleme çıkarma yazılacak sadece zaten update get bu id zaten gerekli değil
    public interface UserRoleRepository
    {
        Task<NoContentDto> RemoveUserAsync(int id);
    }
}
