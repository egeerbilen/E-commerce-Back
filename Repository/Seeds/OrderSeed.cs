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
                    CreatedDate = DateTime.Now,
                    IsDeleted = false
                },
                new Order
                {
                    Id = 2, 
                    CreatedDate = DateTime.Now,
                    IsDeleted = false
                },
                new Order
                {
                    Id = 3, 
                    CreatedDate = DateTime.Now,
                    IsDeleted = false
                },
                new Order
                {
                    Id = 4, 
                    CreatedDate = DateTime.Now,
                    IsDeleted = false
                },
                new Order
                {
                    Id = 5, 
                    CreatedDate = DateTime.Now,
                    IsDeleted = false
                }
            );
        }
    }
}
