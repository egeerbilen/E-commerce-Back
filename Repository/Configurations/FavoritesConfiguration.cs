using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Runtime.ConstrainedExecution;

namespace Repository.Configurations
{
    internal class FavoritesConfiguration : IEntityTypeConfiguration<Favorite>
    {
        public void Configure(EntityTypeBuilder<Favorite> builder)
        {
            // Table name
            builder.ToTable("Favorites");

            // Composite primary key
            builder.HasKey(b => new { b.UserId, b.ProductId });
            // Bu yapı ile Favorite tablosunda FavoriteId sütununa gerek kalmaz ve birincil anahtar olarak UserId ve ProductId
            // sütunlarının birleşimi kullanılır.Bu, her kullanıcı ve ürün çiftinin tabloda yalnızca bir kez bulunmasını garanti eder.

            // Properties
            builder.Property(b => b.UserId).IsRequired();
            builder.Property(b => b.ProductId).IsRequired();

            // Relationships
            builder.HasOne(b => b.User)
                   .WithMany(u => u.Favorites)
                   .HasForeignKey(b => b.UserId);

            builder.HasOne(b => b.Product)
                   .WithMany(p => p.Favorites)
                   .HasForeignKey(b => b.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
