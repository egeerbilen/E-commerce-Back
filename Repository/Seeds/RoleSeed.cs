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
                new Role
                {
                    Id = 1,
                    RoleName = "Admin",
                    CreatedDate = DateTime.Now,
                    IsDeleted = false
                },
                new Role
                {
                    Id = 2,
                    RoleName = "Create",
                    CreatedDate = DateTime.Now,
                    IsDeleted = false
                },
                new Role
                {
                    Id = 3,
                    RoleName = "Update",
                    CreatedDate = DateTime.Now,
                    IsDeleted = false
                },
                new Role
                {
                    Id = 4,
                    RoleName = "Read",
                    CreatedDate = DateTime.Now,
                    IsDeleted = false
                },
                new Role
                {
                    Id = 5,
                    RoleName = "Delete",
                    CreatedDate = DateTime.Now,
                    IsDeleted = false
                }
            );
        }
    }
}
