using Entity.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    internal class BasketProductConfiguration : IEntityTypeConfiguration<BasketProduct>
    {
        public void Configure(EntityTypeBuilder<BasketProduct> builder)
        {
            builder.ToTable("BasketProducts");

            builder.HasKey(bp => new { bp.BasketId, bp.ProductId });

            builder.HasOne(bp => bp.Basket)
                   .WithMany(b => b.BasketProducts)
                   .HasForeignKey(bp => bp.BasketId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(bp => bp.Product)
                   .WithMany(p => p.BasketProducts)
                   .HasForeignKey(bp => bp.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
