using Entity.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

internal class FavoritesSeed : IEntityTypeConfiguration<Favorites>
{
    public void Configure(EntityTypeBuilder<Favorites> builder)
    {
        builder.HasData(
            new Favorites { UserId = 1, ProductId = 1 },
            new Favorites { UserId = 1, ProductId = 2 },
            new Favorites { UserId = 2, ProductId = 2 },
            new Favorites { UserId = 2, ProductId = 3 }
        );
    }
}
