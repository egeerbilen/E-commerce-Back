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

        public async Task<List<Product>> GetProductsByBasketIdAsync(int basketId)
        {
            var userBaskets = await _dbSet
                .Where(ufp => ufp.BasketId == basketId)
                .Where(ufp => ufp.NumberOfProducts != 0)
                .Include(ufp => ufp.Product)
                .AsNoTracking()
                .ToListAsync();

            return userBaskets.Select(ufp => ufp.Product).ToList();
        }

        public async Task<BasketProduct> IsProductInBasketAsync(int basketId, int productId)
        {
            return await _dbSet
                .Where(x => x.BasketId == basketId && x.ProductId == productId)
                .FirstOrDefaultAsync();
        }
        public async Task<List<BasketProduct>> GetBasketIdsByProductIdAsync(int productId)
        {
            var basketsProducts = await _dbSet
                .Where(bp => bp.ProductId == productId)
                .AsNoTracking()
                .ToListAsync();

            return basketsProducts;
        }

        public async Task UpdateProductInBasketAsync(BasketProduct basket)
        {
        }

        public async Task UpdateBasketIdsByProductIdAsync(BasketProduct basket)
        {
            var existingBasketProduct = await _dbSet.FirstOrDefaultAsync(bp => bp.BasketId == basket.BasketId && bp.ProductId == basket.ProductId);

            if (existingBasketProduct != null)
            {
                existingBasketProduct.NumberOfProducts = basket.NumberOfProducts;
                _context.Entry(existingBasketProduct).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }

        }
    }
}
