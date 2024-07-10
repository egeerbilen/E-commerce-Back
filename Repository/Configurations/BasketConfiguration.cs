using Entity.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Configurations
{
    internal class BasketConfiguration : IEntityTypeConfiguration<Basket>
    {
        public void Configure(EntityTypeBuilder<Basket> builder)
        {
            // Table name
            builder.ToTable("Baskets");

            // Composite primary key
            builder.HasKey(b => new { b.UserId, b.ProductId });
            // Bu yapı ile Favorite tablosunda FavoriteId sütununa gerek kalmaz ve birincil anahtar olarak UserId ve ProductId
            // sütunlarının birleşimi kullanılır.Bu, her kullanıcı ve ürün çiftinin tabloda yalnızca bir kez bulunmasını garanti eder.

            // Properties
            builder.Property(b => b.UserId).IsRequired();
            builder.Property(b => b.ProductId).IsRequired();

            // Relationships
            builder.HasOne(b => b.User)
                   .WithMany(u => u.Baskets)
                   .HasForeignKey(b => b.UserId);

            builder.HasOne(b => b.Product)
                   .WithMany(p => p.Baskets)
                   .HasForeignKey(b => b.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
