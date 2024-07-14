using Entity.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Seeds
{
    public class OrderSeed : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasData(
                new Order
                {
                    Id = 1, 
                    UserId = 1, 
                    CreatedDate = DateTime.Now,
                    TotalOrders = 2,
                    IsDeleted = false
                },
                new Order
                {
                    Id = 2,
                    UserId = 1,
                    CreatedDate = DateTime.Now,
                    TotalOrders = 2,
                    IsDeleted = false
                },
                new Order
                {
                    Id = 3,
                    UserId = 1,
                    CreatedDate = DateTime.Now,
                    TotalOrders = 2,
                    IsDeleted = false
                },
                new Order
                {
                    Id = 4,
                    UserId = 2,
                    CreatedDate = DateTime.Now,
                    TotalOrders = 2,
                    IsDeleted = false
                },
                new Order
                {
                    Id = 5,
                    UserId = 2,
                    CreatedDate = DateTime.Now,
                    TotalOrders = 2,
                    IsDeleted = false
                }
            );
        }
    }
}
