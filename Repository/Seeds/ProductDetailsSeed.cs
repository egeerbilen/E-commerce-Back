using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Seeds
{
    internal class ProductDetailsSeed : IEntityTypeConfiguration<ProductDetails>
    {
        public void Configure(EntityTypeBuilder<ProductDetails> builder)
        {
            builder.HasData(
                new ProductDetails
                {
                    Id = 1,
                    ProductId = 1,
                    Description = "Latest model smartphone with advanced features",
                    Stock = 150,
                    CreatedDate = DateTime.Now
                },
                new ProductDetails
                {
                    Id = 2,
                    ProductId = 2,
                    Description = "High-performance laptop for gaming and work",
                    Stock = 100,
                    CreatedDate = DateTime.Now
                },
                new ProductDetails
                {
                    Id = 3,
                    ProductId = 3,
                    Description = "Energy-efficient refrigerator with spacious compartments",
                    Stock = 75,
                    CreatedDate = DateTime.Now
                },
                new ProductDetails
                {
                    Id = 4,
                    ProductId = 4,
                    Description = "Front-loading washing machine with quick wash feature",
                    Stock = 50,
                    CreatedDate = DateTime.Now
                },
                new ProductDetails
                {
                    Id = 5,
                    ProductId = 5,
                    Description = "Best-selling fiction novel",
                    Stock = 200,
                    CreatedDate = DateTime.Now
                }
            );
        }
    }
}
