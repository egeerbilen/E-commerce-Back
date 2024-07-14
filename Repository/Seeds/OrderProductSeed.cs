using Entity.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Seeds
{
    public class OrderProductSeed : IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            builder.HasData(
                new OrderProduct
                {
                    Id = 1,
                    OrderId = 1,
                    ProductId = 1,
                    NumberOfProducts = 1,
                    CreatedDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new OrderProduct
                {
                    Id = 2,
                    OrderId = 1,
                    ProductId = 2,
                    NumberOfProducts = 2,
                    CreatedDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new OrderProduct
                {
                    Id = 3,
                    OrderId = 2,
                    ProductId = 1,
                    NumberOfProducts = 12,
                    CreatedDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new OrderProduct
                {
                    Id = 4,
                    OrderId = 2,
                    ProductId = 3,
                    NumberOfProducts = 23,
                    CreatedDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new OrderProduct
                {
                    Id = 5,
                    OrderId = 3,
                    ProductId = 2,
                    NumberOfProducts = 9,
                    CreatedDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new OrderProduct
                {
                    Id = 6,
                    OrderId = 3,
                    ProductId = 3,
                    NumberOfProducts = 5,
                    CreatedDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new OrderProduct
                {
                    Id = 7,
                    OrderId = 4,
                    ProductId = 1,
                    NumberOfProducts = 10,
                    CreatedDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new OrderProduct
                {
                    Id = 8,
                    OrderId = 4,
                    ProductId = 2,
                    NumberOfProducts = 4,
                    CreatedDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new OrderProduct
                {
                    Id = 9,
                    OrderId = 5,
                    ProductId = 3,
                    NumberOfProducts = 7,
                    CreatedDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new OrderProduct
                {
                    Id = 10,
                    OrderId = 5,
                    ProductId = 1,
                    NumberOfProducts = 15,
                    CreatedDate = DateTime.UtcNow,
                    IsDeleted = false
                }
            );
        }
    }
}
