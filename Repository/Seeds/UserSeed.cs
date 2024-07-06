using Core;
using Entity.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

internal class UserSeed : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        var user1 = new User
        {
            Id = 1,
            FirstName = "Ege",
            LastName = "Erbilen",
            Email = "ege.erbilen@example.com",
            Password = PasswordHelper.HashPassword("password"),
            CreatedDate = DateTime.Now
        };

        var user2 = new User
        {
            Id = 2,
            FirstName = "Ece",
            LastName = "Doe",
            Email = "ece.doe@example.com",
            Password = PasswordHelper.HashPassword("password"),
            CreatedDate = DateTime.Now
        };

        var user3 = new User
        {
            Id = 3,
            FirstName = "Ahmet",
            LastName = "Yılmaz",
            Email = "ahmet.yilmaz@example.com",
            Password = PasswordHelper.HashPassword("password"),
            CreatedDate = DateTime.Now
        };


        var user4 = new User
        {
            Id = 4,
            FirstName = "Mehmet",
            LastName = "Demir",
            Email = "mehmet.demir@example.com",
            Password = PasswordHelper.HashPassword("password"),
            CreatedDate = DateTime.Now
        };
        builder.HasData(user1, user2, user3, user4); // Yeni kullanıcı eklendi
    }
}
