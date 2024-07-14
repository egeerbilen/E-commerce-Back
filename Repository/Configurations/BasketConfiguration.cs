using Entity.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Configurations
{
    internal class BasketConfiguration : IEntityTypeConfiguration<Basket>
    {
        public void Configure(EntityTypeBuilder<Basket> builder)
        {

            builder.ToTable("Baskets");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id).IsRequired();

            builder.HasOne(b => b.User)
                   .WithMany(u => u.Baskets)
                   .HasForeignKey(b => b.UserId);

        }
    }
}
