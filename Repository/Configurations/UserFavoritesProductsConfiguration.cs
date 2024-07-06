using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations
{
    internal class UserFavoritesProductsConfiguration : IEntityTypeConfiguration<UserFavoritesProducts>
    {
        public void Configure(EntityTypeBuilder<UserFavoritesProducts> builder)
        {
            // Table name
            builder.ToTable("UsersFavoritesProducts");

            // Composite primary key
            builder.HasKey(b => new { b.UserId, b.ProductId });

            // Properties
            builder.Property(b => b.UserId).IsRequired();
            builder.Property(b => b.ProductId).IsRequired();

            // Relationships
            builder.HasOne(b => b.User)
                   .WithMany(u => u.UserFavoritesProducts)
                   .HasForeignKey(b => b.UserId)
                   .OnDelete(DeleteBehavior.NoAction); // Silme işlemi için NoAction

            builder.HasOne(b => b.Product)
                   .WithMany(p => p.UserFavoritesProducts)
                   .HasForeignKey(b => b.ProductId)
                   .OnDelete(DeleteBehavior.Cascade); // Silme işlemi için NoAction

            // Indexes
            builder.HasIndex(b => b.UserId).IsUnique(false);
        }
    }
}
