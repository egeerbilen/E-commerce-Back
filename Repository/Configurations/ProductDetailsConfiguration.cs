using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations
{
    internal class ProductDetailsConfiguration : IEntityTypeConfiguration<ProductDetails>
    {
        public void Configure(EntityTypeBuilder<ProductDetails> builder)
        {
            builder.HasKey(pd => pd.Id);
            builder.Property(pd => pd.Id).UseIdentityColumn();
            builder.Property(x => x.Stock).IsRequired();
            builder.Property(pd => pd.Description).IsRequired().HasMaxLength(1000);

            builder.HasOne(pd => pd.Product)
                   .WithOne(p => p.ProductDetails)
                   .HasForeignKey<ProductDetails>(pd => pd.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("ProductDetails");
        }
    }
}
