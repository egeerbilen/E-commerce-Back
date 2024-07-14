using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Seeds
{
    internal class UserRoleSeed : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasData(
                new UserRole { UserId = 1, RoleId = 1 },
                new UserRole { UserId = 2, RoleId = 1 },
                new UserRole { UserId = 2, RoleId = 2 },
                new UserRole { UserId = 3, RoleId = 3 },
                new UserRole { UserId = 4, RoleId = 2 },
                new UserRole { UserId = 5, RoleId = 2 },
                new UserRole { UserId = 6, RoleId = 3 },
                new UserRole { UserId = 7, RoleId = 3 },
                new UserRole { UserId = 8, RoleId = 2 },
                new UserRole { UserId = 9, RoleId = 3 },
                new UserRole { UserId = 10, RoleId = 4 }
            );
        }
    }
}
