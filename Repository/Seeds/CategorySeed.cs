using Core.Model;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Seeds
{
    internal class CategorySeed : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {

            builder.HasData(
                new Category { Id = 1, Name = "Electronics", CreatedDate = DateTime.Now, IsDeleted = false },
                new Category { Id = 2, Name = "Home Appliances", CreatedDate = DateTime.Now, IsDeleted = false },
                new Category { Id = 3, Name = "Books", CreatedDate = DateTime.Now, IsDeleted = false },
                new Category { Id = 4, Name = "Clothing", CreatedDate = DateTime.Now, IsDeleted = false },
                new Category { Id = 5, Name = "Toys", CreatedDate = DateTime.Now, IsDeleted = false },
                new Category { Id = 6, Name = "Sports", CreatedDate = DateTime.Now, IsDeleted = false },
                new Category { Id = 7, Name = "Beauty", CreatedDate = DateTime.Now, IsDeleted = false },
                new Category { Id = 8, Name = "Health", CreatedDate = DateTime.Now, IsDeleted = false },
                new Category { Id = 9, Name = "Automotive", CreatedDate = DateTime.Now, IsDeleted = false },
                new Category { Id = 10, Name = "Furniture", CreatedDate = DateTime.Now, IsDeleted = false },
                new Category { Id = 11, Name = "Grocery", CreatedDate = DateTime.Now, IsDeleted = false },
                new Category { Id = 12, Name = "Jewelry", CreatedDate = DateTime.Now, IsDeleted = false },
                new Category { Id = 13, Name = "Music", CreatedDate = DateTime.Now, IsDeleted = false }
            );
        }
    }
}
