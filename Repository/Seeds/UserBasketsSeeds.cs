using Entity.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Seeds
{
    internal class UserBasketsSeeds : IEntityTypeConfiguration<UserBaskets>
    {
        public void Configure(EntityTypeBuilder<UserBaskets> builder)
        {
            builder.HasData(
                new UserBaskets { UserId = 1, ProductId = 1 },
                new UserBaskets { UserId = 1, ProductId = 3 },
                new UserBaskets { UserId = 2, ProductId = 1 },
                new UserBaskets { UserId = 2, ProductId = 3 }
            );
        }
    }

}
