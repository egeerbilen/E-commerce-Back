using Core.DTOs;
using Entity.DTOs;
using Entity.Model;
using Entity.Repositories;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Repositories;

namespace DataAccess.Repositories
{
    public class UserFavoritesProductsRepository : IUserFavoritesProductsRepository
    {
        protected readonly AppDbContext _context;
        // dbSet bizim veri tabanındaki tablomuza karşılık geliyor
        // readonly çünkü bu değişkenler constroctur ve ya altta değer atana bilir sonrasında değer atanamaz
        private readonly DbSet<UserFavoritesProducts> _dbSet;
        public UserFavoritesProductsRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<UserFavoritesProducts>();
        }
        public async Task<UserFavoritesProducts> CreateUserFavoriteProductsAsync(UserFavoritesProducts userFavoritesProducts)
        {
            // Yeni favori ürünü ekle
            _context.UserFavoritesProducts.AddAsync(userFavoritesProducts);

            // Değişiklikleri kaydet
            await _context.SaveChangesAsync();

            // Güncellenmiş favori ürünü al
            var updatedUserFavorite = await _context.UserFavoritesProducts
                .Where(u => u.UserId == userFavoritesProducts.UserId)
                .FirstOrDefaultAsync();

            return updatedUserFavorite;
        }

        public async Task<bool> DeleteUserFavoriteProductsAsync(int userId, int productId)
        {
            var userFavoriteProduct = await _context.UserFavoritesProducts.FirstOrDefaultAsync(u => u.UserId == userId && u.ProductId == productId);

            if (userFavoriteProduct != null)
            {
                _context.UserFavoritesProducts.Remove(userFavoriteProduct);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<List<Product>> GetUserFavoritesById(int userId)
        {
            var userFavorites = await _context.UserFavoritesProducts
                .Where(ufp => ufp.UserId == userId)
                .Include(ufp => ufp.Product)
                .AsNoTracking()
                .ToListAsync();

            return userFavorites.Select(ufp => ufp.Product).ToList();
        }
    }
}
