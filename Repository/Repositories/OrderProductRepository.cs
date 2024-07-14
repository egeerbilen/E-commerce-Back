using Core.DTOs;
using Entity.Model;
using Entity.Repositories;
using NLayer.Core.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace DataAccess.Repositories
{
    public class OrderProductRepository : IOrderProductRepository
    {
        private readonly AppDbContext _context;

        public OrderProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<NoContentDto> CreateOrderProductAsync(List<OrderProduct> orderProducts)
        {
            // Yeni OrderProduct öğelerini veritabanına ekleme
            await _context.OrdersProducts.AddRangeAsync(orderProducts);
            await _context.SaveChangesAsync();

            // İşlemin başarılı olduğunu belirtmek için NoContentDto döndürüyoruz
            return new NoContentDto();
        }

        public async Task<List<Order>> GetUserOrderProducts(int userId)
        {
            return await _context.Orders
                       .Where(order => order.UserId == userId)
                       .Include(order => order.OrderProducts)
                       .ThenInclude(op => op.Product)
                       .ToListAsync();
        }

    }
}
