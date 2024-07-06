using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Seeds
{
    internal class RoleSeed : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(
                new Role { Id = 1, RoleName = "Admin", CreatedDate = DateTime.Now },
                new Role { Id = 2, RoleName = "User", CreatedDate = DateTime.Now },
                new Role { Id = 3, RoleName = "Guest", CreatedDate = DateTime.Now }
            );
        }
    }
}
