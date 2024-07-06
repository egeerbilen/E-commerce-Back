using Entity.Model;
using Entity.Repositories;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace DataAccess.Repositories
{
    public class UserBasketRespository : IUserBasketRepository
    {
        protected readonly AppDbContext _context;
        // dbSet bizim veri tabanındaki tablomuza karşılık geliyor
        // readonly çünkü bu değişkenler constroctur ve ya altta değer atana bilir sonrasında değer atanamaz
        private readonly DbSet<UserBasketRespository> _dbSet;
        public UserBasketRespository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<UserBasketRespository>();
        }
        public async Task<UserBaskets> CreateUserBasketProductsAsync(UserBaskets userBaskets)
        {
            // Yeni favori ürünü ekle
            _context.userBaskets.AddAsync(userBaskets);

            // Değişiklikleri kaydet
            await _context.SaveChangesAsync();

            // Güncellenmiş favori ürünü al
            var updatedUserBasket = await _context.userBaskets
                .Where(u => u.UserId == userBaskets.UserId)
                .FirstOrDefaultAsync();

            return updatedUserBasket;
        }

        public async Task<bool> DeleteUserBasketProductsAsync(int userId, int productId)
        {
            var userBasketProduct = await _context.userBaskets.FirstOrDefaultAsync(u => u.UserId == userId && u.ProductId == productId);

            if (userBasketProduct != null)
            {
                _context.userBaskets.Remove(userBasketProduct);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
