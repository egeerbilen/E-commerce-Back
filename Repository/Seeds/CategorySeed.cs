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
                new Category { Id = 1, Name = "Electronics", CreatedDate = DateTime.Now },
                new Category { Id = 2, Name = "Home Appliances", CreatedDate = DateTime.Now },
                new Category { Id = 3, Name = "Books", CreatedDate = DateTime.Now }
            );
        }
    }
}
