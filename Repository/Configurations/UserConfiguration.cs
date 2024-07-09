using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.Address).HasMaxLength(500);

            builder.HasCheckConstraint("FirstName", "LEN(FirstName) >= 3");
            builder.HasCheckConstraint("LastName", "LEN(LastName) >= 3");

            // Relationships
            builder.HasMany(u => u.UserRoles)
                   .WithOne()
                   .HasForeignKey(ur => ur.UserId);

            builder.HasMany(u => u.Products)
                   .WithOne(p => p.User)
                   .HasForeignKey(p => p.UserId);

            builder.HasMany(u => u.Favorites)
                   .WithOne(ufp => ufp.User)
                   .HasForeignKey(ufp => ufp.UserId);

            // DeleteBehavior.Cascade: İlişkili kayıtları otomatik olarak siler(döngü veya çoklu yol sorunlarına neden olabilir).
            // DeleteBehavior.NoAction: Silme işlemi sırasında herhangi bir işlem yapmaz, ancak veri tutarsızlıklarına neden olabilir.
            // DeleteBehavior.SetNull: İlişkili kayıtların yabancı anahtarlarını null olarak ayarlar.
            // DeleteBehavior.Restrict: Silme işlemini kısıtlar ve hata verir.

            builder.ToTable("Users");
        }
    }
}
