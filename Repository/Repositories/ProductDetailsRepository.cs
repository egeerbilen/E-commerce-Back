using Entity.Model;
using Entity.Repositories;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Repositories;

namespace NLayer.Repository.Repositories
{
    public class ProductDetailsRepository : GenericRepository<ProductDetails>, IProductDetailsRepository
    {
        public ProductDetailsRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<ProductDetails> GetProductDetailsWithProductAsync(int id)
        {
            return await _context.ProductDetails
                .Where(pd => pd.ProductId == id)
                .Include(x => x.Product)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

    }
}
