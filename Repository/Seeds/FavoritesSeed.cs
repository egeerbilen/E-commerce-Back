using Entity.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

internal class FavoritesSeed : IEntityTypeConfiguration<Favorite>
{
    public void Configure(EntityTypeBuilder<Favorite> builder)
    {
        builder.HasData(
            new Favorite { UserId = 1, ProductId = 1 },
            new Favorite { UserId = 1, ProductId = 2 },
            new Favorite { UserId = 2, ProductId = 2 },
            new Favorite { UserId = 2, ProductId = 3 }
        );
    }
}
