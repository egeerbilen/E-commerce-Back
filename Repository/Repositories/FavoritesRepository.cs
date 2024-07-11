using Core.DTOs;
using Entity.DTOs;
using Entity.Model;
using Entity.Repositories;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Repositories;

namespace DataAccess.Repositories
{
    public class FavoritesRepository : IFavoritesRepository
    {
        protected readonly AppDbContext _context;
        // dbSet bizim veri tabanındaki tablomuza karşılık geliyor
        // readonly çünkü bu değişkenler constroctur ve ya altta değer atana bilir sonrasında değer atanamaz
        private readonly DbSet<Favorite> _dbSet;
        public FavoritesRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Favorite>();
        }
        public async Task<Favorite> CreateUserFavoriteProductAsync(Favorite favorites)
        {
            // Yeni favori ürünü ekle
            _context.Favorites.AddAsync(favorites);

            // Değişiklikleri kaydet
            await _context.SaveChangesAsync();

            // Güncellenmiş favori ürünü al
            var updatedUserFavorite = await _context.Favorites
                .Where(u => u.UserId == favorites.UserId)
                .FirstOrDefaultAsync();

            return updatedUserFavorite;
        }

        public async Task<bool> DeleteUserFavoriteProductAsync(int userId, int productId)
        {
            var userFavoriteProduct = await _context.Favorites.FirstOrDefaultAsync(u => u.UserId == userId && u.ProductId == productId);

            if (userFavoriteProduct != null)
            {
                _context.Favorites.Remove(userFavoriteProduct);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<List<Product>> GetUserFavoritesByIdAsync(int userId)
        {
            var userFavorites = await _context.Favorites
                .Where(ufp => ufp.UserId == userId)
                .Include(ufp => ufp.Product)
                .AsNoTracking()
                .ToListAsync();

            return userFavorites.Select(ufp => ufp.Product).ToList();
        }

        public async Task<List<Favorite>> GetProductFavoritesByIdAsync(int productId)
        {
            return  await _context.Favorites
                .Where(f => f.ProductId == productId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<bool> IsFavoriteProductAsync(int userId, int productId)
        {
            return await _context.Favorites
                                 .Where(x => x.UserId == userId)
                                 .Where(y => y.ProductId == productId)
                                 .AsNoTracking()
                                 .FirstOrDefaultAsync() != null;
        }
    }
}
