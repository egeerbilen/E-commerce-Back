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
            await _context.OrderProducts.AddRangeAsync(orderProducts);
            await _context.SaveChangesAsync();

            // İşlemin başarılı olduğunu belirtmek için NoContentDto döndürüyoruz
            return new NoContentDto();
        }

        public async Task<List<Order>> GetUserOrders(int userId)
        {
            // Belirtilen kullanıcıya ait siparişleri getirme
            var orders = await _context.Orders
                .Include(o => o.OrderProducts)
                .ThenInclude(op => op.Product)
                .Where(o => o.UserId == userId)
                .ToListAsync();

            return orders;
        }
    }
}
