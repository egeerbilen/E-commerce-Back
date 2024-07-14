using Core.DTOs;
using Entity.Model;
using Entity.Repositories;
using NLayer.Core.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Repositories;

namespace DataAccess.Repositories
{
    public class OrderProductRepository : GenericRepository<OrderProduct>, IOrderProductRepository
    {
        private readonly AppDbContext _context;

        public OrderProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<NoContentDto> CreateOrderProductAsync(List<OrderProduct> orderProducts)
        {
            // Yeni OrderProduct öğelerini veritabanına ekleme
            await _context.OrdersProducts.AddRangeAsync(orderProducts);
            await _context.SaveChangesAsync();

            // İşlemin başarılı olduğunu belirtmek için NoContentDto döndürüyoruz
            return new NoContentDto();
        }

        public async Task<List<Product>> GetOrderProductsAsync(int orderId)
        {
            var orderProducts = await _context.OrdersProducts
                .Where(op => op.OrderId == orderId)
                .Include(op => op.Product) // İlişkili Product nesnesini dahil ediyoruz
                .Select(op => op.Product) // Sadece Product nesnesini seçiyoruz
                .ToListAsync();

            return orderProducts;
        }

        public async Task<List<Order>> GetUserOrderProductsAsync(int userId)
        {
            return await _context.Orders
                       .Where(order => order.UserId == userId)
                       .Include(order => order.OrderProducts)
                       .ThenInclude(op => op.Product)
                       .ToListAsync();
        }

    }
}
