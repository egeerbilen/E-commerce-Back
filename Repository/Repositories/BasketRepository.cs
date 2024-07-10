

using Entity.Model;
using Entity.Repositories;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace DataAccess.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<Basket> _dbSet;
        public BasketRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Basket>();
        }

        public async Task<Basket> CreateUserBasketProductsAsync(Basket basket)
        {
            _context.Baskets.AddAsync(basket);

            await _context.SaveChangesAsync();

            var updatedUserBasket = await _context.Baskets
                .Where(u => u.UserId == basket.UserId)
                .FirstOrDefaultAsync();

            return updatedUserBasket;
        }

        public async Task<bool> DeleteUserBasketProductsAsync(int userId, int productId)
        {
            var userBasketProduct = await _context.Baskets.FirstOrDefaultAsync(u => u.UserId == userId && u.ProductId == productId);

            if (userBasketProduct != null)
            {
                _context.Baskets.Remove(userBasketProduct);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<List<Product>> GetUserBasketsById(int userId)
        {
            var userBaskets = await _context.Baskets
                .Where(ufp => ufp.UserId == userId)
                .Include(ufp => ufp.Product)
                .AsNoTracking()
                .ToListAsync();

            return userBaskets.Select(ufp => ufp.Product).ToList();
        }

        public async Task<bool> IsBasketProduct(int userId, int productId)
        {
            return await _context.Baskets
                                 .Where(x => x.UserId == userId)
                                 .Where(y => y.ProductId == productId)
                                 .AsNoTracking()
                                 .FirstOrDefaultAsync() != null;
        }
    }
}
