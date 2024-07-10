using Entity.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Seeds
{
    public class BasketSeed : IEntityTypeConfiguration<Basket>
    {
        public void Configure(EntityTypeBuilder<Basket> builder)
        {
            builder.HasData(
                new Basket { UserId = 1, ProductId = 1 },
                new Basket { UserId = 1, ProductId = 3 },
                new Basket { UserId = 1, ProductId = 4 },
                new Basket { UserId = 2, ProductId = 1 },
                new Basket { UserId = 2, ProductId = 3 }
            );
        }
    }
}
