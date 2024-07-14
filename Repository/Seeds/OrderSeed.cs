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
                    TotalOrders = 1,
                    TotalPrice = 150,
                    CustomerId = 3,
                    IsDeleted = false
                },
                new Order
                {
                    Id = 2,
                    UserId = 1,
                    CreatedDate = DateTime.Now,
                    TotalOrders = 22,
                    TotalPrice = 1350,
                    CustomerId = 3,
                    IsDeleted = false
                },
                new Order
                {
                    Id = 3,
                    UserId = 1,
                    CreatedDate = DateTime.Now,
                    TotalOrders = 3,
                    CustomerId = 3,
                    TotalPrice = 121,
                    IsDeleted = false
                },
                new Order
                {
                    Id = 4,
                    UserId = 2,
                    CreatedDate = DateTime.Now,
                    TotalOrders = 5,
                    CustomerId = 5,
                    TotalPrice = 230,
                    IsDeleted = false
                },
                new Order
                {
                    Id = 5,
                    UserId = 2,
                    CreatedDate = DateTime.Now,
                    TotalOrders = 2,
                    TotalPrice = 430,
                    CustomerId = 2,
                    IsDeleted = false
                }
            );
        }
    }
}
