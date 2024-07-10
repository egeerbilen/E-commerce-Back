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
            CreatedDate = DateTime.Now,
            IsDeleted = false
        };

        var user2 = new User
        {
            Id = 2,
            FirstName = "Ece",
            LastName = "Erbilen",
            Email = "ece.erbilen@example.com",
            Password = PasswordHelper.HashPassword("password"),
            CreatedDate = DateTime.Now,
            IsDeleted = false
        };

        var user3 = new User
        {
            Id = 3,
            FirstName = "Ahmet",
            LastName = "Yılmaz",
            Email = "ahmet.yilmaz@example.com",
            Password = PasswordHelper.HashPassword("password"),
            CreatedDate = DateTime.Now,
            IsDeleted = false
        };

        var user4 = new User
        {
            Id = 4,
            FirstName = "Ayşe",
            LastName = "Kara",
            Email = "ayse.kara@example.com",
            Password = PasswordHelper.HashPassword("password"),
            CreatedDate = DateTime.Now,
            IsDeleted = false
        };

        var user5 = new User
        {
            Id = 5,
            FirstName = "Mehmet",
            LastName = "Demir",
            Email = "mehmet.demir@example.com",
            Password = PasswordHelper.HashPassword("password"),
            CreatedDate = DateTime.Now,
            IsDeleted = false
        };

        var user6 = new User
        {
            Id = 6,
            FirstName = "Fatma",
            LastName = "Çelik",
            Email = "fatma.celik@example.com",
            Password = PasswordHelper.HashPassword("password"),
            CreatedDate = DateTime.Now,
            IsDeleted = false
        };

        var user7 = new User
        {
            Id = 7,
            FirstName = "Ali",
            LastName = "Öztürk",
            Email = "ali.ozturk@example.com",
            Password = PasswordHelper.HashPassword("password"),
            CreatedDate = DateTime.Now,
            IsDeleted = false
        };

        var user8 = new User
        {
            Id = 8,
            FirstName = "Zeynep",
            LastName = "Yıldız",
            Email = "zeynep.yildiz@example.com",
            Password = PasswordHelper.HashPassword("password"),
            CreatedDate = DateTime.Now,
            IsDeleted = false
        };

        var user9 = new User
        {
            Id = 9,
            FirstName = "Mustafa",
            LastName = "Şahin",
            Email = "mustafa.sahin@example.com",
            Password = PasswordHelper.HashPassword("password"),
            CreatedDate = DateTime.Now,
            IsDeleted = false
        };

        var user10 = new User
        {
            Id = 10,
            FirstName = "Elif",
            LastName = "Koç",
            Email = "elif.koc@example.com",
            Password = PasswordHelper.HashPassword("password"),
            CreatedDate = DateTime.Now,
            IsDeleted = false
        };

        builder.HasData(user1, user2, user3, user4, user5, user6, user7, user8, user9, user10);

    }
}
