using Entity.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class UserBasketConfiguration : IEntityTypeConfiguration<UserBaskets>
{
    public void Configure(EntityTypeBuilder<UserBaskets> builder)
    {
        // Tablo adı
        builder.ToTable("UserBaskets");

        // Birleşik anahtar
        builder.HasKey(b => new { b.UserId, b.ProductId });

        // Özellikler
        builder.Property(b => b.UserId).IsRequired();
        builder.Property(b => b.ProductId).IsRequired();

        builder.HasOne(ub => ub.User)
               .WithMany(u => u.UserBaskets)
               .HasForeignKey(ub => ub.UserId)
               .OnDelete(DeleteBehavior.Restrict); 

        builder.HasOne(ub => ub.Product)
               .WithMany(p => p.UserBaskets)
               .HasForeignKey(ub => ub.ProductId)
               .OnDelete(DeleteBehavior.Restrict); 

        // İndeksler
        builder.HasIndex(b => b.UserId).IsUnique(false);
    }
}
