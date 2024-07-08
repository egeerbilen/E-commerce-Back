using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Repository.Seeds
{
    internal class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product
                {
                    Id = 1,
                    UserId = 1,
                    CategoryId = 1,
                    Name = "Product 1",
                    Price = 100.0m,
                    CreatedDate = DateTime.Now,
                    ImageData = null // veya varsayılan bir değer koyabilirsiniz
                },
                new Product
                {
                    Id = 2,
                    UserId = 1,
                    CategoryId = 1,
                    Name = "Product 2",
                    Price = 200.0m,
                    CreatedDate = DateTime.Now,
                    ImageData = null
                },
                new Product
                {
                    Id = 3,
                    UserId = 2,
                    CategoryId = 2,
                    Name = "Product 3",
                    Price = 150.0m,
                    CreatedDate = DateTime.Now,
                    ImageData = null
                },
                new Product
                {
                    Id = 4,
                    UserId = 2,
                    CategoryId = 2,
                    Name = "Product 4",
                    Price = 250.0m,
                    CreatedDate = DateTime.Now,
                    ImageData = null
                },
                new Product
                {
                    Id = 5,
                    UserId = 3,
                    CategoryId = 3,
                    Name = "Product 5",
                    Price = 300.0m,
                    CreatedDate = DateTime.Now,
                    ImageData = null
                }
            );
        }
    }
}
