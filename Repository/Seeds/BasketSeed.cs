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
                new Basket { Id = 1, UserId = 1, CreatedDate = DateTime.Now, IsDeleted = false },
                new Basket { Id = 2, UserId = 2, CreatedDate = DateTime.Now, IsDeleted = false },
                new Basket { Id = 3, UserId = 3, CreatedDate = DateTime.Now, IsDeleted = false },
                new Basket { Id = 4, UserId = 4, CreatedDate = DateTime.Now, IsDeleted = false },
                new Basket { Id = 5, UserId = 5, CreatedDate = DateTime.Now, IsDeleted = false },
                new Basket { Id = 6, UserId = 6, CreatedDate = DateTime.Now, IsDeleted = false },
                new Basket { Id = 7, UserId = 7, CreatedDate = DateTime.Now, IsDeleted = false },
                new Basket { Id = 8, UserId = 8, CreatedDate = DateTime.Now, IsDeleted = false },
                new Basket { Id = 9, UserId = 9, CreatedDate = DateTime.Now, IsDeleted = false },
                new Basket { Id = 10, UserId = 10, CreatedDate = DateTime.Now, IsDeleted = false }
            );
        }
    }
}
