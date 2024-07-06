using Entity.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

internal class UserFavoritesProductsSeed : IEntityTypeConfiguration<UserFavoritesProducts>
{
    public void Configure(EntityTypeBuilder<UserFavoritesProducts> builder)
    {
        builder.HasData(
            new UserFavoritesProducts { UserId = 1, ProductId = 1 },
            new UserFavoritesProducts { UserId = 1, ProductId = 2 },
            new UserFavoritesProducts { UserId = 2, ProductId = 2 },
            new UserFavoritesProducts { UserId = 2, ProductId = 3 }
        );
    }
}
