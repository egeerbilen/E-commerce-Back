using Entity.Model;
using Entity.Repositories;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace DataAccess.Repositories
{
    public class BasketProductRepository : IBasketProductRepository
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<Basket> _dbSet;

        public BasketProductRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Basket>();
        }

        public async Task<Basket> CreateUserBasketProductAsync(Basket basket)
        {
            await _dbSet.AddAsync(basket);
            await _context.SaveChangesAsync();

            var updatedUserBasket = await _dbSet
                .Where(u => u.UserId == basket.UserId)
                .FirstOrDefaultAsync();

            return updatedUserBasket;
        }

        public async Task<bool> DeleteUserBasketProductAsync(int userId, int basketId)
        {
            var userBasketProduct = await _dbSet.FirstOrDefaultAsync(u => u.UserId == userId && u.Id == basketId);

            if (userBasketProduct != null)
            {
                _dbSet.Remove(userBasketProduct);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<List<Product>> GetUserBasketsByIdAsync(int userId)
        {
            var userBaskets = await _dbSet
                .Where(ufp => ufp.UserId == userId)
                .Include(ufp => ufp.BasketProducts)
                    .ThenInclude(bp => bp.Product)
                .AsNoTracking()
                .ToListAsync();

            return userBaskets.SelectMany(ufp => ufp.BasketProducts.Select(bp => bp.Product)).ToList();
        }

        public async Task<bool> IsBasketProductAsync(int userId, int productId)
        {
            return await _dbSet
                .Where(x => x.UserId == userId)
                .SelectMany(b => b.BasketProducts)
                .AnyAsync(bp => bp.ProductId == productId);
        }
    }
}
