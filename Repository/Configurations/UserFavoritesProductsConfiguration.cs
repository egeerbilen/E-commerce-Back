using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Runtime.ConstrainedExecution;

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
            // Bu yapı ile Favorite tablosunda FavoriteId sütununa gerek kalmaz ve birincil anahtar olarak UserId ve ProductId
            // sütunlarının birleşimi kullanılır.Bu, her kullanıcı ve ürün çiftinin tabloda yalnızca bir kez bulunmasını garanti eder.

            // Properties
            builder.Property(b => b.UserId).IsRequired();
            builder.Property(b => b.ProductId).IsRequired();

            // Relationships
            builder.HasOne(b => b.User)
                   .WithMany(u => u.UserFavoritesProducts)
                   .HasForeignKey(b => b.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(b => b.Product)
                   .WithMany(p => p.UserFavoritesProducts)
                   .HasForeignKey(b => b.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
