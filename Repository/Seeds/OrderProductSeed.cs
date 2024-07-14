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
                    OrderId = 1,
                    ProductId = 1,
                    NumberOfProducts = 1,
                },
                new OrderProduct
                {
                    OrderId = 1,
                    ProductId = 2,
                    NumberOfProducts = 2,
                },
                new OrderProduct
                {
                    OrderId = 2,
                    ProductId = 1,
                    NumberOfProducts = 12,
                },
                new OrderProduct
                {
                    OrderId = 2,
                    ProductId = 3,
                    NumberOfProducts = 23,
                },
                new OrderProduct
                {
                    OrderId = 3,
                    ProductId = 2,
                    NumberOfProducts = 9
                }
            );
        }
    }
}
