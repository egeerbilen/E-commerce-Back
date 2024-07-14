
using Entity.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Seeds
{
    public class BasketProductSeed : IEntityTypeConfiguration<BasketProduct>
    {
        public void Configure(EntityTypeBuilder<BasketProduct> builder)
        {
            builder.HasData(
                 new BasketProduct { BasketId = 1, ProductId = 1, NumberOfProducts = 2 },
                 new BasketProduct { BasketId = 1, ProductId = 3, NumberOfProducts = 1 },
                 new BasketProduct { BasketId = 1, ProductId = 4, NumberOfProducts = 1 },
                 new BasketProduct { BasketId = 2, ProductId = 1, NumberOfProducts = 1 },
                 new BasketProduct { BasketId = 2, ProductId = 3, NumberOfProducts = 1 },
                 new BasketProduct { BasketId = 3, ProductId = 2, NumberOfProducts = 1 },
                 new BasketProduct { BasketId = 3, ProductId = 4, NumberOfProducts = 1 },
                 new BasketProduct { BasketId = 3, ProductId = 5, NumberOfProducts = 1 },
                 new BasketProduct { BasketId = 4, ProductId = 1, NumberOfProducts = 1 },
                 new BasketProduct { BasketId = 4, ProductId = 2, NumberOfProducts = 1 },
                 new BasketProduct { BasketId = 4, ProductId = 3, NumberOfProducts = 1 },
                 new BasketProduct { BasketId = 5, ProductId = 1, NumberOfProducts = 1 },
                 new BasketProduct { BasketId = 5, ProductId = 2, NumberOfProducts = 1 },
                 new BasketProduct { BasketId = 5, ProductId = 4, NumberOfProducts = 1 }
             );
        }
    }
}
