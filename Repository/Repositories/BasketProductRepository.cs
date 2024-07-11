using Core.DTOs;
using Entity.Model;
using Entity.Repositories;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace DataAccess.Repositories
{
    public class BasketProductRepository : IBasketProductRepository
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<BasketProduct> _dbSet;

        public BasketProductRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<BasketProduct>();
        }

        public async Task AddProductToBasketAsync(BasketProduct basket)
        {
            await _dbSet.AddAsync(basket);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> RemoveProductFromBasketAsync(int basketId, int productId)
        {
            var userBasketProduct = await _dbSet.FirstOrDefaultAsync(u => u.BasketId == basketId && u.ProductId == productId);

            if (userBasketProduct != null)
            {
                _dbSet.Remove(userBasketProduct);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<List<Product>> GetProductsByBasketIdAsync(int basketId)
        {
            var userBaskets = await _dbSet
                .Where(ufp => ufp.BasketId == basketId)
                .Include(ufp => ufp.Product)
                .AsNoTracking()
                .ToListAsync();

            return userBaskets.Select(ufp => ufp.Product).ToList();
        }

        public async Task<bool> IsProductInBasketAsync(int userId, int productId)
        {
            return await _dbSet
                .Where(x => x.BasketId == userId && x.ProductId == productId)
                .AnyAsync();
        }
        public async Task<List<BasketProduct>> GetBasketIdsByProductIdAsync(int productId)
        {
            var basketsProducts = await _dbSet
                .Where(bp => bp.ProductId == productId)
                .AsNoTracking()
                .ToListAsync();

            return basketsProducts;
        }
    }
}
